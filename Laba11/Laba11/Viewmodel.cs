using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Laba11
{
    class Viewmodel
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        string imagePath;
        Viewmodel()
        {
            Addtotovar = new DelegateCommand(AddTOvar);
            Delete = new DelegateCommand(Deletes);
            Addzakaz = new DelegateCommand(addzakaz);
            Sort1 = new DelegateCommand(sort1);
            Sort2 = new DelegateCommand(sort2);
            Sort3 = new DelegateCommand(transaction);
            Update = new DelegateCommand(update);
            Addph = new DelegateCommand(LoadImage);
            vivod();
            vivodtovat();
        }
        public ICommand Addph
        {
            get; set;
        }
        public ICommand Sort1
        {
            get; set;
        }
        public ICommand Sort2
        {
            get; set;
        }
        public ICommand Sort3
        {
            get; set;
        }
        public ICommand Addzakaz
        {
            get; set;
        }

        public ICommand Delete
        {
            get; set;
        }
        public ICommand Addtotovar
        {
            get;
            set;
        }
        public ICommand Update
        {
            get;
            set;
        }


        public ObservableCollection<Tovar> tools1 { get; set; } = new ObservableCollection<Tovar>();
        public ObservableCollection<Zakaz> zakazs { get; set; } = new ObservableCollection<Zakaz>();
        public void AddTOvar(object obj)
        {

            string sqlExpression = "INSERT INTO Tovar (names, typess, cost, info) VALUES ('" + Nick + "', '" + Curtools + "', '" + Add_Cost + "', '" + Info + "')";
            tools1.Add(new Tovar { Name = Nick, Cost = Add_Cost, Types = Curtools, Coun = Info });
            string id;
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            id = (string)command.ExecuteScalar();
            connection.Close();

        }
        public void addzakaz(object obj)
        {

            string sqlExpression = "INSERT INTO Zakaz (namesss, cost, client, Photo) VALUES ('" + Curtools1.Name + "', '" + Curtools1.Cost + "', '" + User + "', '" + imagePath + "' )";
            zakazs.Add(new Zakaz { Name = Curtools1.Name, Cost = Curtools1.Cost, Client = User });
            string id;
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            id = (string)command.ExecuteScalar();
            connection.Close();

        }
        public void Deletes(object obj)
        {

            string sqlExpression = "Delete From Tovar where = '" + Curtools1.Name + "'";


            string id;
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            id = (string)command.ExecuteScalar();
            connection.Close();
            foreach (var t in tools1)
            {
                if (t.Name == Curtools1.Name)
                {
                    // Delete(t);
                }
            }

        }
        

        void LoadImage(object obj)
        {
      
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
               
                imagePath = openFileDialog.FileName;
            }
        }
      
        public void update(object obj)
        {
            vivod();
            vivodtovat();


        }
        public void transaction(object obj)
        {
           
            
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // выполняем две отдельные команды
                    command.CommandText = "select  * from Tovar order by  names";
                    command.ExecuteNonQuery();
                    command.CommandText = "select  * from Tovar where names  = '" + SEarch + "'";
                    command.ExecuteNonQuery();

                    // подтверждаем транзакцию
                    transaction.Commit();
                  MessageBox.Show("Данные добавлены в базу данных");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errod");
                    transaction.Rollback();
                }
            connection.Close();
        }
        public void vivod()
        {
            zakazs.Clear();
            string sql = "allzakaz";
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    zakazs.Add(new Zakaz { Id = reader.GetInt32(0),
                        Name = Convert.ToString(reader.GetValue(1)), 
                        Cost = Convert.ToString(reader.GetValue(2)),
                        Client = reader.GetString(3),
                    Photo = reader.GetString(4)});
                }
            }
            reader.Close();
            connection.Close();
        }
        public void editzakaz(object obj)
        {
            string sql = "Update  Zakaz set [namesss]='" + Curtools1.Name + "' where [ids] = '" + Curzakaz.Id + "'";
            Curzakaz.Name = Curtools1.Name;
            string id;
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            id = (string)command.ExecuteScalar();
            connection.Close();
        }
        public void vivodtovat()
        {
            string sql = "alltovar";
            tools1.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tools1.Add(new Tovar { Name = reader.GetString(0), Cost = Convert.ToString(reader.GetValue(2)), Types = reader.GetString(1), Coun = reader.GetString(3) });
                }
            }
            reader.Close();
            connection.Close();

        }
        public void sort1(object obj)
        {
            
                string sql = "select  * from Tovar order by  names ";
            tools1.Clear();
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                    tools1.Add(new Tovar { Name = reader.GetString(0), Cost = Convert.ToString(reader.GetValue(2)), Types = reader.GetString(1), Coun = reader.GetString(3) });
                }
                }
                reader.Close();
                connection.Close();

            
        }
        public void sort2(object obj)
        {

            string sql = "select  * from Tovar order by  typess ";
            tools1.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tools1.Add(new Tovar { Name = reader.GetString(0), Cost = Convert.ToString(reader.GetValue(2)), Types = reader.GetString(1), Coun = reader.GetString(3) });
                }
            }
            reader.Close();
            connection.Close();


        }
        public void sort3(object obj)
        {

            string sql = "select  * from Tovar where names  = '" + SEarch +"'"; 
            tools1.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tools1.Add(new Tovar { Name = reader.GetString(0), Cost = Convert.ToString(reader.GetValue(2)), Types = reader.GetString(1), Coun = reader.GetString(3) });
                }
            }
            reader.Close();
            connection.Close();


        }
        private string nick;
        public string Nick
        {
            get { return nick; }
            set
            {
                nick = value;
            }
        }
        private string curtools;
        public string Curtools
        {
            get { return curtools; }
            set
            {
                curtools = value;

            }
        }
        private string search;
        public string SEarch
        {
            get { return search; }
            set
            {
                search = value;

            }
        }
        private Zakaz curzakaz;
        public Zakaz Curzakaz
        {
            get { return curzakaz; }
            set
            {
                curzakaz = value;

            }
        }
        private string user;
        public string User
        {
            get { return user; }
            set
            {
                user = value;

            }
        }
        private Tovar curtools1;
        public Tovar Curtools1
        {
            get { return curtools1; }
            set
            {
                curtools1 = value;

            }
        }
        private string add_Cost;
        public string Add_Cost
        {
            get { return add_Cost; }
            set
            {
                add_Cost = value;

            }
        }
        private string info;
        public string Info
        {
            get { return info; }
            set
            {
                info = value;

            }
        }
        private string types;
        public string Types
        {
            get { return types; }
            set
            {
                types = value;

            }
        }
        public static Viewmodel instance = null;
        public static Viewmodel getInstance()
        {
            if (instance == null)
                instance = new Viewmodel();
            return instance;
        }

    }
}
