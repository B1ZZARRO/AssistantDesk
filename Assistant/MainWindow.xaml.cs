using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Assistant.Models;
using RestSharp;

namespace Assistant
{
    public partial class MainWindow : Window
    {
        private RestClient apiClient = ServiceBuilder.GetInstance();
        private RestClient apiClientUser = ServiceBuilderUser.GetInstance();
        private MediaPlayer player = new MediaPlayer();
        private readonly Window _parentWindow;
        private string sResponse;
        private int id;
        private bool play_pause;

        public MainWindow(int sId, string sName, Window parent)
        {
            InitializeComponent();
            _parentWindow = parent;
            lbl_request.Text = "";
            lbl_response.Text = "";
            btn_mus.Visibility = Visibility.Hidden;
            btn_pause.Visibility = Visibility.Hidden;
            id = sId;
            lbl_welcome.Text = "Здравствуйте " + sName + "! Чем могу помочь?";
            UpdateHistory();
        }

        private void Btn_send_OnClick(object sender, RoutedEventArgs e)
        {
            if(tb_request.Text == "") MessageBox.Show("Поле запроса было пустым, отправьте запрос ещё раз");
            else
            {
                lbl_request.Text = tb_request.Text;
                tb_request.Text = "";
                if (play_pause == true) player.Pause();
                btn_pause.Visibility = Visibility.Hidden;
                btn_mus.Visibility = Visibility.Hidden;
                lbl_response.Text = "";
                AddNewRequest();
            }
        }

        private void Btn_exit_OnClick(object sender, RoutedEventArgs e)
        {
            player.Stop();
            Hide();
            new AuthWindow().Show();
        }
        
        private void AddNewRequest()
        {
            var response = apiClient.Post<ResponseModel>(new RestRequest("/request/")
                .AddHeader("Content-Type","application/json").AddJsonBody(new
                {
                    query = lbl_request.Text,
                    key = "yznU4jvZPKnvAGyLw1jiDbFXU5zdMC8b",
                    unit = "1648137875994"
                }));
            if (response.Text == "") lbl_response.Text = "Запрос не найден, попробуйте найти что-то ещё";
            else
            {
                if (lbl_response != null) lbl_response.Text = response?.Text;
                sResponse = response.Text;
            }
            if (response?.Intent == "/Date and Time/Current time")
            {
                lbl_response.Text = DateTime.Now.ToString("HH:mm");
                sResponse = DateTime.Now.ToString("HH:mm");
            }

            if (response.Intent == "/Music/Init" && response.Text !=
                "Что-то я не могу найти подходящую музыку. Может включим что-нибудь другое?")
            {
                btn_mus.Visibility = Visibility.Visible;
                try
                {
                    player.Open(new Uri(response.Data.Stream, UriKind.Absolute));
                    player.Play();
                    player.Volume = 0.1;
                    play_pause = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка воспроизведения");
                }
            }
            else btn_mus.Visibility = Visibility.Hidden;
            AddHistory();
            UpdateHistory();
        }

        private void AddHistory()
        {
            var response = apiClientUser.Post<AddHistoryModel>(new RestRequest("/AddHistory/")
                .AddJsonBody(new
                {
                    query = lbl_request.Text,
                    response = sResponse,
                    userID = id,
                    date = DateTime.Now.ToString("dd.MM.yy HH:mm")
                }));
        }

        private void UpdateHistory()
        {
            var response = apiClientUser.Get<HistoryModel>(new RestRequest("/History/").AddQueryParameter("id", id));
            List<History> history = new List<History>();	
            for (int i = 0; i < response?.Body.Count; i++)
            {
                history.Add(new History (response.Body[i].Query + "\n" + response.Body[i].Response + "\n" + response.Body[i].Date + "\n"));
            }
            list_history.ItemsSource = history;
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_mus_OnClick(object sender, RoutedEventArgs e)
        {
            player.Pause();
            play_pause = false;
            btn_pause.Visibility = Visibility.Visible;
            btn_mus.Visibility = Visibility.Hidden;
        }

        private void Btn_pause_OnClick(object sender, RoutedEventArgs e)
        {
            player.Play();
            play_pause = true;
            btn_mus.Visibility = Visibility.Visible;
            btn_pause.Visibility = Visibility.Hidden;
        }
    }
}