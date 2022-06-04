using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assistant.Models;
using Microsoft.VisualBasic;
using RestSharp;

namespace Assistant
{
    public partial class MainWindow : Window
    {
        private RestClient apiClient = ServiceBuilder.GetInstance();
        private RestClient apiClientUser = ServiceBuilderUser.GetInstance();
        //private MediaPlayer player = new MediaPlayer();\
        private readonly Window _parentWindow;
        private string sResponse;
        private int id;
        
        public MainWindow(int sId, string sName, Window parent)
        {
            InitializeComponent();
            _parentWindow = parent;
            lbl_request.Content = "";
            lbl_response.Content = "";
            id = sId;
            lbl_welcome.Content = "Здравствуйте " + sName + "! Чем могу помочь?";
            UpdateHistory();
        }

        private void Btn_send_OnClick(object sender, RoutedEventArgs e)
        {
            if(tb_request.Text == "") MessageBox.Show("Поле запроса было пустым, отправьте запрос ещё раз");
            else
            {
                lbl_request.Content = tb_request.Text;
                tb_request.Text = "";
                //медиаплеер
                lbl_response.Content = "";
                AddNewRequest();
            }
        }

        private void Btn_exit_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            _parentWindow.Show();
        }
        
        private void AddNewRequest()
        {
            var response = apiClient.Post<ResponseModel>(new RestRequest("/request/")
                .AddHeader("Content-Type","application/json").AddJsonBody(new
                {
                    query = lbl_request.Content,
                    key = "yznU4jvZPKnvAGyLw1jiDbFXU5zdMC8b",
                    unit = "1648137875994"
                }));
            if (response.Text == "") lbl_response.Content = "Запрос не найден, попробуйте найти что-то ещё";
            else
            {
                if (lbl_response != null) lbl_response.Content = response?.Text;
                sResponse = response.Text;
            }
            if (response?.Intent == "/Date and Time/Current time")
            {
                lbl_response.Content = DateTime.Now.ToString("HH:mm");
                sResponse = DateTime.Now.ToString("HH:mm");
            }
            if (response.Intent == "/Music/Init" && response.Text !=
                "Что-то я не могу найти подходящую музыку. Может включим что-нибудь другое?")
            {
                
                //включить видимость плеера
                try
                {
                    //player.Open(new Uri(response.Data.Stream, UriKind.Relative));
                    //player.Play();
                    //включение медиаплеера
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка воспроизведения");
                }
            }
            //else отключить видимость плеера
            //обработка нажатия паузы 
            AddHistory();
            UpdateHistory();
        }

        private void AddHistory()
        {
            var response = apiClientUser.Post<HistoryModel>(new RestRequest("/AddHistory/")
                .AddJsonBody(new
                {
                    query = lbl_request.Content,
                    response = sResponse,
                    userID = id,
                    date = DateTime.Now.ToString("dd.MM.yy HH:mm")
                }));
            //UpdateHistory();
        }

        private void UpdateHistory()
        {
            var response = apiClientUser.Get<HistoryModel>(new RestRequest("/History/").AddQueryParameter("id", id));
            List<History> history = new List<History>();	
            for (int i = 0; i < response?.Body.Count; i++)
            {
                history.Add(new History (response.Body[i].Query + "\n" + response.Body[i].Response + "\n" + response.Body[i].Date + "\n"));
            }
            listViewProfMinsk.ItemsSource = history;
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}