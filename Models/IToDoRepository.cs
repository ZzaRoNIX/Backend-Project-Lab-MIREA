using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Timers;
using System.Reflection.Metadata;

namespace WebServiceSV1.Models
{
    public interface ITodoRepository
    {
        string Add(TodoItem item);
        string GetAll(TodoItem item);
       string Find(TodoItem item);
        void Remove(TodoItem item);
        string Update(TodoItem item);
        string Archive(TodoItem item);
    }
    
    public class TodoRepository : ITodoRepository
    {
        
        private static ConcurrentDictionary<string, TodoItem> _todos =
              new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            SetTimer(); //вызов таймера
            Add(new TodoItem { TaskName = "Item1" });
        }

        public string GetAll(TodoItem item)
        {
            if (item.UserID == null) { return ""; }
            int rtes = CheckUserH(item.UserID);
            if (rtes == -1)
            {
                return "";
            }

            {
                // создание обьекта соединения
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = TodoItem.cs;
                //   cnn.Open();
                // создание обьекта команды скл серверу
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec GetAllTask '" + item.UserID + "','" + item.Flag + "'";
                cmd.Connection = cnn;
                // установили соединение
                // исполнили команду
                cmd.Connection.Open();
                string res = cmd.ExecuteScalar().ToString();
                cmd.Connection.Close();
                return res;
            }
        }


        public string Add(TodoItem item)
        {
            //быстра проверка(каждые 2 сек) на юзера
            int rtes = CheckUserH(item.UserID);
            if (item.UserID==null) { return ""; }
            if(rtes == -1) {
                return "";
            }

            {
                // создание обьекта соединения
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = TodoItem.cs;
                //   cnn.Open();
                // создание обьекта команды скл серверу
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec CreateTask '" + item.UserID + "','" + item.TaskName + "','" + item.TaskDescription + "'";
                cmd.Connection = cnn;
                // установили соединение
                // исполнили команду
                cmd.Connection.Open();
                string res = cmd.ExecuteScalar().ToString();
                cmd.Connection.Close();
                return res;
            }
        }

       
        public string Find(TodoItem item)
        {
            if (item.UserID == null) { return ""; }
            int rtes = CheckUserH(item.UserID);
            if (rtes == -1) {
                return "";
            }

            {
                // создание обьекта соединения
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = TodoItem.cs;
                //   cnn.Open();
                // создание обьекта команды скл серверу
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec SelectTaskDate '" + item.UserID + "','" + item.StartDate + "','" + item.EndDate + "'";
                cmd.Connection = cnn;
                // установили соединение
                // исполнили команду
                cmd.Connection.Open();
                string res = cmd.ExecuteScalar().ToString();
                cmd.Connection.Close();
                return res;
            }
        }

        public void Remove(TodoItem item)
        {
            if (item.UserID == null) { return ; }
            int rtes = CheckUserH(item.UserID);
            if (rtes == -1) {
                return;
            }

            {
                // создание обьекта соединения
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = TodoItem.cs;
                //   cnn.Open();
                // создание обьекта команды скл серверу
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec DeleteTask '" + item.UserID + "','" + item.CurrentCounter + "'";
                cmd.Connection = cnn;
                // установили соединение
                // исполнили команду
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public string Update(TodoItem item)
        {
            if (item.UserID == null) { return ""; }
            int rtes = CheckUserH(item.UserID);
            if (rtes == -1) {
                return "";
            }

            { 
                // создание обьекта соединения
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = TodoItem.cs;
                //   cnn.Open();
                // создание обьекта команды скл серверу
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec UpdateTask '" + item.UserID + "','" + item.CurrentCounter + "','" + item.TaskDescription + "'";
                cmd.Connection = cnn;
                // установили соединение
                // исполнили команду
                cmd.Connection.Open();
                string res = cmd.ExecuteScalar().ToString();
                cmd.Connection.Close();
                return res;
            }
        }

        public string Archive(TodoItem item)
        {
            if (item.UserID == null) { return ""; }
            int rtes = CheckUserH(item.UserID);
            if (rtes == -1) {
                return "";
            }

            {
                // создание обьекта соединения
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = TodoItem.ms;
                //   cnn.Open();
                // создание обьекта команды скл серверу
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec ChangeFlag '" + item.UserID + "','" + item.CurrentCounter + "'";
                cmd.Connection = cnn;
                // установили соединение
                // исполнили команду
                cmd.Connection.Open();
                string res = cmd.ExecuteScalar().ToString();
                cmd.Connection.Close();
                return res;
            }
        }



        //таймер
        private void SetTimer()
        {
            //Создаём таймер, который будет срабатывать каждые 10 сек
            var aTimer = new Timer(10000);
            //Назначаем обработчик, который будет срабатывать по таймауту
            aTimer.Elapsed += OnTimedEvent;
            //Таймер будет постоянно работать
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            UsersH.Clear();
        }
        private int CheckUserH(string UserID)
        {
            foreach (string u in UsersH)
            {
                if (u == UserID)
                {
                    return -1;
                }
            }
            UsersH.Add(UserID); 
            return 0;
        }

       private List<string> UsersH=new List<String>();
       
    }
}
