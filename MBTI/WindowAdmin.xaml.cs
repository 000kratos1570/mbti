using Npgsql;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace MBTI
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            using (NpgsqlConnection con = Person.GetConnection())
            {
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter("select ID_Profile as \"ID_Profile\",Login as \"Логин\",Surname as \"Фамилия\",MyName as \"Имя\",Patronymic as \"Отчество\" from Profile inner join Users on ID_Users = Users_ID;", con);
                DataTable dataTable = new DataTable();
                npgsqlDataAdapter.Fill(dataTable);

                DGUsers.ItemsSource = dataTable.DefaultView;
                DGUsers.SelectedValuePath = "ID_Profile";
                DGUsers.CanUserDeleteRows = false;
                DGUsers.CanUserAddRows = false;
                DGUsers.IsReadOnly = true;
                DGUsers.SelectionMode = DataGridSelectionMode.Single;
            }
        }

        public bool Volid()
        {
            if (TBLogin.Text.Trim() != "Логин" && TBLogin.Text.Trim() != "" && TBLogin.Text != null &&
                TBF.Text.Trim() != "Фамилия" && TBF.Text.Trim() != "" && TBF.Text != null &&
                TBI.Text.Trim() != "Имя" && TBI.Text.Trim() != "" && TBI.Text != null)
            {
                using (NpgsqlConnection con = Person.GetConnection())
                {
                    con.Open();
                    NpgsqlDataAdapter exist = new NpgsqlDataAdapter($"select * from Users where Login = '{TBLogin.Text.Trim()}'", con);
                    DataTable existdata = new DataTable();
                    exist.Fill(existdata);
                    if (existdata.Rows.Count != 0)
                        return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BTadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Volid())
                {
                    using (NpgsqlConnection con = Person.GetConnection())
                    {
                        con.Open();

                        int ids;

                        NpgsqlCommand user = new NpgsqlCommand($"CALL Users_insert('{TBLogin.Text.Trim()}','{TBPass.Text.Trim()}');", con);
                        user.ExecuteScalar();

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter($"select ID_Users from Users where Login = '{TBLogin.Text.Trim()}'", con);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        int.TryParse(data.Rows[0][0].ToString(), out ids);

                        if (TBO.Text.Trim() != "Отчество (если есть)" && TBO.Text.Trim() != "" && TBO.Text != null)
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"insert into Profile(Surname,MyName,Patronymic,MyGroup_ID,College_ID,Cource_ID,Users_ID) values ('{TBF.Text.Trim()}','{TBI.Text.Trim()}','{TBO.Text.Trim()}',1,1,1,{ids});", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }
                        else
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"insert into Profile(Surname,MyName,MyGroup_ID,College_ID,Cource_ID,Users_ID) values ('{TBF.Text.Trim()}','{TBI.Text.Trim()}',1,1,1,{ids});", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }

                        NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter("select ID_Profile as \"ID_Profile\",Login as \"Логин\",Surname as \"Фамилия\",MyName as \"Имя\",Patronymic as \"Отчество\" from Profile inner join Users on ID_Users = Users_ID;", con);
                        DataTable dataTable = new DataTable();
                        npgsqlDataAdapter.Fill(dataTable);

                        DGUsers.ItemsSource = dataTable.DefaultView;
                        DGUsers.SelectedValuePath = "ID_Profile";
                        DGUsers.CanUserDeleteRows = false;
                        DGUsers.CanUserAddRows = false;
                        DGUsers.IsReadOnly = true;
                        DGUsers.SelectionMode = DataGridSelectionMode.Single;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка введённых данных");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка введённых данных");
            }
        }

        private void BTReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Volid())
                {
                    using (NpgsqlConnection con = Person.GetConnection())
                    {
                        con.Open();

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter($"select Users_ID from Profile where ID_Profile = {DGUsers.SelectedValue}", con);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        NpgsqlCommand user = new NpgsqlCommand($"CALL Users_update({data.Rows[0][0]},'{TBLogin.Text.Trim()}','{TBPass.Text.Trim()}');", con);
                        user.ExecuteScalar();

                        if (TBO.Text.Trim() != "Отчество (если есть)" && TBO.Text.Trim() != "" && TBO.Text != null)
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"update Profile set Surname='{TBF.Text.Trim()}',MyName='{TBI.Text.Trim()}',Patronymic='{TBO.Text.Trim()}' where ID_Profile={DGUsers.SelectedValue};", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }
                        else
                        {
                            NpgsqlCommand aa = new NpgsqlCommand($"update Profile set Surname='{TBF.Text.Trim()}',MyName='{TBI.Text.Trim()}' where ID_Profile={DGUsers.SelectedValue};", con);
                            aa.Prepare();
                            aa.ExecuteNonQuery();
                        }
                        NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter("select ID_Profile as \"ID_Profile\",Login as \"Логин\",Surname as \"Фамилия\",MyName as \"Имя\",Patronymic as \"Отчество\" from Profile inner join Users on ID_Users = Users_ID;", con);
                        DataTable dataTable = new DataTable();
                        npgsqlDataAdapter.Fill(dataTable);

                        DGUsers.ItemsSource = dataTable.DefaultView;
                        DGUsers.SelectedValuePath = "ID_Profile";
                        DGUsers.CanUserDeleteRows = false;
                        DGUsers.CanUserAddRows = false;
                        DGUsers.IsReadOnly = true;
                        DGUsers.SelectionMode = DataGridSelectionMode.Single;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка введённых данных");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка введённых данных");
            }
        }

        private void BTDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGUsers.SelectedItem != null)
                using (NpgsqlConnection con = Person.GetConnection())
                {
                    con.Open();
                    NpgsqlCommand aa = new NpgsqlCommand($"CALL MBTI_delete({DGUsers.SelectedValue});", con);
                    aa.Prepare();
                    aa.ExecuteNonQuery();

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter($"select Users_ID from Profile where ID_Profile = {DGUsers.SelectedValue}", con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    aa = new NpgsqlCommand($"CALL profile_delete({DGUsers.SelectedValue});", con);
                    aa.Prepare();
                    aa.ExecuteNonQuery();

                    aa = new NpgsqlCommand($"CALL users_delete({data.Rows[0][0].ToString()});", con);
                    aa.Prepare();
                    aa.ExecuteNonQuery();

                    NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter("select ID_Profile as \"ID_Profile\",Login as \"Логин\",Surname as \"Фамилия\",MyName as \"Имя\",Patronymic as \"Отчество\" from Profile inner join Users on ID_Users = Users_ID;", con);
                    DataTable dataTable = new DataTable();
                    npgsqlDataAdapter.Fill(dataTable);

                    DGUsers.ItemsSource = dataTable.DefaultView;
                    DGUsers.SelectedValuePath = "ID_Profile";
                    DGUsers.CanUserDeleteRows = false;
                    DGUsers.CanUserAddRows = false;
                    DGUsers.IsReadOnly = true;
                    DGUsers.SelectionMode = DataGridSelectionMode.Single;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка введённых данных");
            }
        }

        private void DGUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)DGUsers.SelectedItem;
            if (dataRowView != null)
            {
                using (NpgsqlConnection con = Person.GetConnection())
                {
                    TBLogin.Text = dataRowView.Row.ItemArray[1].ToString();
                    TBF.Text = dataRowView.Row.ItemArray[2].ToString();
                    TBI.Text = dataRowView.Row.ItemArray[3].ToString();
                    TBO.Text = dataRowView.Row.ItemArray[4].ToString();
                    TBPass.Text = "Пароль";
                }

            }
        }

        private void DGUsers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "ID_Profile")
            {
                e.Cancel = true;
            }
        }

        private void BTEx_Click(object sender, RoutedEventArgs e)
        {
            new WindowLogIn().Show();
            Close();
        }
    }
}
