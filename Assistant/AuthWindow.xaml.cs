using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Assistant.Models;
using RestSharp;

namespace Assistant
{
    public partial class AuthWindow : Window
    {
        private RestClient apiClientUser = ServiceBuilderUser.GetInstance();
        private RememberMe _rememberMe = null;

        public AuthWindow()
        {
            InitializeComponent();
            _rememberMe = RememberMe.GetRememberMe();
            _initControlls();
        }

        private void _initControlls()
        {
            tb_login.Text = _rememberMe.Login;
            tb_password.Text = _rememberMe.Password;
            if (_rememberMe.Check == true) cb_remember.IsChecked = true;
        }

        private void Auth()
        {
            var response = apiClientUser.Post<UserModel>(new RestRequest("/Auth/")
                .AddJsonBody(new
                {
                    login = tb_login.Text,
                    password = tb_password.Text
                }));
            if (response?.Message == "Ok")
            {
                Hide();
                new MainWindow(response.Body.UserID, response.Body.Name, this).Show();
            }
            else lbl_error.Content = "Неверный Логин или пароль";
        }

        private void Login()
        {
            var response = apiClientUser.Get<UsersModel>(new RestRequest("/Login/").AddQueryParameter("login", tb_login.Text));
            if (tb_login.Text == "" || tb_password.Text == "") lbl_error.Content = "Не все поля заполнены";
            else
            {
                try
                {
                    if (tb_login.Text == response.Body[0].Login) lbl_error.Content = "Данный логин уже используется";
                }
                catch (Exception e)
                {
                    Hide();
                    new RegWindow(tb_login.Text, tb_password.Text, this).Show();
                }
            }
        }

        private void Btn_auth_OnClick(object sender, RoutedEventArgs e)
        {
            if (cb_remember.IsChecked == true)
            {
                _rememberMe.Login = tb_login.Text;
                _rememberMe.Password = tb_password.Text;
                _rememberMe.Check = true;
                _rememberMe.Save();
            }
            else
            {
                _rememberMe.Login = "";
                _rememberMe.Password = "";
                _rememberMe.Check = false;
                _rememberMe.Save();
            }
            Auth();
        }

        private void Btn_reg_OnClick(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Lbl_enter_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Hide();
            new MainWindow(0, "", this).Show();
        }

        private void AuthWindow_OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}