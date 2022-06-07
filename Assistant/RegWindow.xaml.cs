using System;
using System.Windows;
using Assistant.Models;
using RestSharp;

namespace Assistant
{
    public partial class RegWindow : Window
    {
        private RestClient apiClientUser = ServiceBuilderUser.GetInstance();
        private readonly Window _parentRegWindow;
        private string sLogin;
        private string sPassword;
        
        public RegWindow(string login, string password, Window regParent)
        {
            InitializeComponent();
            _parentRegWindow = regParent;
            sLogin = login;
            sPassword = password;
        }

        private void Reg()
        {
            var response = apiClientUser.Post<UserModel>(new RestRequest("/Reg/")
                .AddJsonBody(new
                {
                    login = sLogin,
                    password = sPassword,
                    name = tb_name.Text
                }));
            if (response?.Message == "Ok" && tb_name.Text != "")
            {
                Hide();
                new MainWindow(response.Body.UserID, response.Body.Name, this).Show();
            }
            else lbl_error.Content = "Неверное имя пользоваателя";
        }

        private void Btn_reg_OnClick(object sender, RoutedEventArgs e)
        {
            Reg();
        }

        private void RegWindow_OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}