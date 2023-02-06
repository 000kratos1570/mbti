using Npgsql;
using System;
using System.Data;
using System.Windows;

namespace MBTI
{
    /// <summary>
    /// Логика взаимодействия для WindowProfile.xaml
    /// </summary>
    public partial class WindowProfile : Window
    {
        DataTable ID_Usersdata;
        public WindowProfile()
        {
            InitializeComponent();

            using (NpgsqlConnection con = Person.GetConnection())
            {
                con.Open();

                NpgsqlDataAdapter ID_Usersadapter = new NpgsqlDataAdapter($"select ID_Users from Users where Login = '{Person.Login}'", con);
                ID_Usersdata = new DataTable();
                ID_Usersadapter.Fill(ID_Usersdata);

                NpgsqlDataAdapter Surnameadapter = new NpgsqlDataAdapter($"select Surname from Profile where Users_ID = {ID_Usersdata.Rows[0][0]};", con);
                DataTable Surnamedata = new DataTable();
                Surnameadapter.Fill(Surnamedata);

                NpgsqlDataAdapter MyNameadapter = new NpgsqlDataAdapter($"select MyName from Profile where Users_ID = {ID_Usersdata.Rows[0][0]};", con);
                DataTable MyNamedata = new DataTable();
                MyNameadapter.Fill(MyNamedata);

                NpgsqlDataAdapter Patronymicadapter = new NpgsqlDataAdapter($"select Patronymic from Profile where Users_ID = {ID_Usersdata.Rows[0][0]};", con);
                DataTable Patronymicdata = new DataTable();
                Patronymicadapter.Fill(Patronymicdata);

                int[] ids = new int[3];

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter($"select MyGroup_ID from Profile where Users_ID = {ID_Usersdata.Rows[0][0]};", con);
                DataTable data = new DataTable();
                adapter.Fill(data);

                int.TryParse(data.Rows[0][0].ToString(), out ids[0]);

                adapter = new NpgsqlDataAdapter($"select College_ID from Profile where Users_ID = {ID_Usersdata.Rows[0][0]};", con);
                data = new DataTable();
                adapter.Fill(data);

                int.TryParse(data.Rows[0][0].ToString(), out ids[1]);

                adapter = new NpgsqlDataAdapter($"select Cource_ID from Profile where Users_ID = {ID_Usersdata.Rows[0][0]};", con);
                data = new DataTable();
                adapter.Fill(data);

                int.TryParse(data.Rows[0][0].ToString(), out ids[2]);

                NpgsqlDataAdapter MyGroupadapter = new NpgsqlDataAdapter($"select MyGroup from MyGroup where ID_MyGroup = {ids[0]}", con);
                DataTable MyGroupdata = new DataTable();
                MyGroupadapter.Fill(MyGroupdata);

                NpgsqlDataAdapter Collegeadapter = new NpgsqlDataAdapter($"select College from College where ID_College = {ids[1]}", con);
                DataTable Collegedata = new DataTable();
                Collegeadapter.Fill(Collegedata);

                NpgsqlDataAdapter Courceadapter = new NpgsqlDataAdapter($"select Cource from Cource where ID_Cource = {ids[2]}", con);
                DataTable Courcedata = new DataTable();
                Courceadapter.Fill(Courcedata);


                TBLogin.Text = Person.Login;
                TBF.Text = Surnamedata.Rows[0][0].ToString();
                TBI.Text = MyNamedata.Rows[0][0].ToString();
                TBO.Text = Patronymicdata.Rows[0][0].ToString();
                TBCource.Text = Courcedata.Rows[0][0].ToString();
                TBGroup.Text = MyGroupdata.Rows[0][0].ToString();
                TBCollege.Text = Collegedata.Rows[0][0].ToString();
            }
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
                        return null;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BTStart_Click(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Close();
        }

        private void BTEx_Click(object sender, RoutedEventArgs e)
        {
            new WindowLogIn().Show();
            Close();
        }

        private void BTReg_Click(object sender, RoutedEventArgs e)
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

                        adapter = new NpgsqlDataAdapter($"select ID_Profile from Profile where Users_ID = {ID_Usersdata.Rows[0][0].ToString()}", con);
                        data = new DataTable();
                        adapter.Fill(data);

                        int.TryParse(data.Rows[0][0].ToString(), out ids[3]);

                        NpgsqlCommand user = new NpgsqlCommand($"CALL Users_update({ID_Usersdata.Rows[0][0].ToString()},'{TBLogin.Text.Trim()}','{TBPass.Text.Trim()}');", con);
                        user.ExecuteScalar();

                        if (TBO.Text.Trim() != "Отчество (если есть)" && TBO.Text.Trim() != "" && TBO.Text != null)
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"update Profile set Surname='{TBF.Text.Trim()}',MyName='{TBI.Text.Trim()}',Patronymic='{TBO.Text.Trim()}',MyGroup_ID={ids[0]},College_ID={ids[1]},Cource_ID={ids[2]} where ID_Profile={ids[3]};", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }
                        else
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"update Profile set Surname='{TBF.Text.Trim()}',MyName='{TBI.Text.Trim()}',MyGroup_ID={ids[0]},College_ID={ids[1]},Cource_ID={ids[2]} where ID_Profile={ids[3]};", con);
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
