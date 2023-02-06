using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace MBTI
{
    /// <summary>
    /// Логика взаимодействия для WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void BTReg_Click(object sender, RoutedEventArgs e)
        {
            new WindowLogIn().Show();
            Close();
        }

        public bool? Volid()
        {
            int t;
            if (TBLogin.Text.Trim() != "Логин" && TBLogin.Text.Trim() != "" && TBLogin.Text != null &&
                TBPass.Text.Trim() != "Пароль" && TBPass.Text.Trim() != "" && TBPass.Text != null &&
                TBF.Text.Trim() != "Фамилия" && TBF.Text.Trim() != "" && TBF.Text != null &&
                TBI.Text.Trim() != "Имя" && TBI.Text.Trim() != "" && TBI.Text != null &&
                TBCource.Text.Trim() != "Курс" && TBCource.Text.Trim() != "" && TBCource.Text != null &&
                Int32.TryParse(TBCource.Text.Trim(), out t) &&
                TBGroup.Text.Trim() != "Группа" && TBGroup.Text.Trim() != "" && TBGroup.Text != null &&
                TBCollege.Text.Trim() != "Техникум" && TBCollege.Text.Trim() != "" && TBCollege.Text != null
                )
            {
                using (NpgsqlConnection con = Person.GetConnection())
                {
                    con.Open();
                    NpgsqlDataAdapter exist = new NpgsqlDataAdapter($"select * from Users where Login = '{TBLogin.Text.Trim()}'", con);
                    DataTable existdata = new DataTable();
                    exist.Fill(existdata);
                    if (existdata.Rows.Count != 0)
                    {
                        return null;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BTReg_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Volid() == true)
                {
                    using (NpgsqlConnection con = Person.GetConnection())
                    {
                        con.Open();

                        try
                        {
                            NpgsqlCommand gr = new NpgsqlCommand($"insert into MyGroup(MyGroup) values('{TBGroup.Text.Trim()}');", con);
                            gr.ExecuteScalar();
                        }
                        catch { }
                        try
                        {
                            NpgsqlCommand co = new NpgsqlCommand($"insert into College(College) values('{TBCollege.Text.Trim()}');", con);
                            co.ExecuteScalar();
                        }
                        catch { }
                        try
                        {
                            NpgsqlCommand cou = new NpgsqlCommand($"insert into Cource(Cource) values({TBCource.Text.Trim()});", con);
                            cou.ExecuteScalar();
                        }
                        catch { }

                        int[] ids = new int[4];

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter($"select ID_MyGroup from MyGroup where MyGroup = '{TBGroup.Text.Trim()}'", con);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        int.TryParse(data.Rows[0][0].ToString(), out ids[0]);

                        adapter = new NpgsqlDataAdapter($"select ID_College from College where College = '{TBCollege.Text.Trim()}'", con);
                        data = new DataTable();
                        adapter.Fill(data);

                        int.TryParse(data.Rows[0][0].ToString(), out ids[1]);

                        adapter = new NpgsqlDataAdapter($"select ID_Cource from Cource where Cource = '{TBCource.Text.Trim()}'", con);
                        data = new DataTable();
                        adapter.Fill(data);

                        int.TryParse(data.Rows[0][0].ToString(), out ids[2]);

                        NpgsqlCommand user = new NpgsqlCommand($"CALL Users_insert('{TBLogin.Text.Trim()}','{TBPass.Text.Trim()}');", con);
                        user.ExecuteScalar();

                        adapter = new NpgsqlDataAdapter($"select ID_Users from Users where Login = '{TBLogin.Text.Trim()}'", con);
                        data = new DataTable();
                        adapter.Fill(data);

                        int.TryParse(data.Rows[0][0].ToString(), out ids[3]);


                        if (TBO.Text.Trim() != "Отчество (если есть)" && TBO.Text.Trim() != "" && TBO.Text != null)
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"insert into Profile(Surname,MyName,Patronymic,MyGroup_ID,College_ID,Cource_ID,Users_ID) values ('{TBF.Text.Trim()}','{TBI.Text.Trim()}','{TBO.Text.Trim()}',{ids[0]},{ids[1]},{ids[2]},{ids[3]});", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }
                        else
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"insert into Profile(Surname,MyName,MyGroup_ID,College_ID,Cource_ID,Users_ID) values ('{TBF.Text.Trim()}','{TBI.Text.Trim()}',{ids[0]},{ids[1]},{ids[2]},{ids[3]});", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }
                        Person.Login = TBLogin.Text.Trim();
                        new WindowProfile().Show();
                        Close();
                    }
                }
                else if (Volid() == false)
                {
                    MessageBox.Show("Ошибка введённых данных");
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка введённых данных");
            }
        }
    }
}
