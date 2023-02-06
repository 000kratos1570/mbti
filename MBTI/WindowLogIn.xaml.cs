using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows;

namespace MBTI
{
    /// <summary>
    /// Логика взаимодействия для WindowLogIn.xaml
    /// </summary>
    public partial class WindowLogIn : Window
    {
        public WindowLogIn()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            VersionCheck();
        }

        public bool InternetOK()
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry("dns.msftncsi.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void VersionCheck()
        {
            string curver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string exename = AppDomain.CurrentDomain.FriendlyName;
            string exepath = Assembly.GetEntryAssembly().Location;

            using (WebClient wc = new WebClient())
            {
                if (InternetOK())
                {
                    string readver = wc.DownloadString("");
                    if (Convert.ToDouble(curver,CultureInfo.InvariantCulture) == Convert.ToDouble(readver, CultureInfo.InvariantCulture))
                    {
                        MessageBox.Show("У вас самая последняя версия программы", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Доступна более новая версия. Обновить?","",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            wc.DownloadFile("","new.exe");
                            Cmd($"taskkill /f /im \"{exename}\" $$ timeout /t 1 $$ del \"{exepath}\" && ren new.exe \"{exename}\" && {exepath}");
                        }
                    }
                }
                else
                    MessageBox.Show("Нет доступа в сеть для проверки версии.\nВы можете продожить работать в текущей версии","",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        public void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden,
            });
        }

        private void BTReg_Click(object sender, RoutedEventArgs e)
        {
            new WindowRegister().Show();
            Close();
        }

        private void BTLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text.Trim() != "Логин" && TBLogin.Text.Trim() != "" && TBLogin.Text != null && TBPass.Text.Trim() != "Пароль" && TBPass.Text.Trim() != "" && TBPass.Text != null)
            {
                using (NpgsqlConnection con = Person.GetConnection())
                {
                    NpgsqlDataAdapter IsTrueLogin = new NpgsqlDataAdapter($"select ID_Users from Users where Login = '{TBLogin.Text.Trim()}';", con);
                    DataTable dataIsTrueLogin = new DataTable();
                    IsTrueLogin.Fill(dataIsTrueLogin);
                    if (dataIsTrueLogin.Rows.Count == 0)
                    {
                        MessageBox.Show("Неверный логин");
                    }
                    else
                    {
                        con.Open();
                        NpgsqlCommand IsTruePass = new NpgsqlCommand($"select GetHashPass('{TBLogin.Text.Trim()}','{TBPass.Text.Trim()}');", con);
                        string ispas = IsTruePass.ExecuteScalar().ToString();
                        if (ispas == "True")
                        {
                            Person.Login = TBLogin.Text.Trim();
                            NpgsqlDataAdapter IsAdmin = new NpgsqlDataAdapter($"select * from Admins where Users_ID = {dataIsTrueLogin.Rows[0][0].ToString()};", con);
                            DataTable dataAdmin = new DataTable();
                            IsAdmin.Fill(dataAdmin);
                            if (dataAdmin.Rows.Count != 0)
                            {
                                new WindowAdmin().Show();
                                Close();
                            }
                            else
                            {
                                new WindowProfile().Show();
                                Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль");
                        }
                    }
                }
            }
        }
    }
}
