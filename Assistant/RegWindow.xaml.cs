﻿using System;
using System.Windows;
using Assistant.Models;
using RestSharp;

namespace Assistant
{
    public partial class RegWindow : Window
    {
        private RestClient apiClientUser = ServiceBuilderUser.GetInstance();
        private string sLogin;
        private string sPassword;
        
        public RegWindow(string login, string password)
        {
            InitializeComponent();
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
                MainWindow mainWindow = new MainWindow(response.Body.UserID, response.Body.Name);
                mainWindow.ShowDialog();
            }
            else lbl_error.Content = "Неверное имя пользоваателя";
        }

        private void Btn_reg_OnClick(object sender, RoutedEventArgs e)
        {
            Reg();
        }
    }
}