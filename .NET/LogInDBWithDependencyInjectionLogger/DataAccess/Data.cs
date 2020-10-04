using Model;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace DataAccess
{
    /// <summary>
    /// class to store and retrive data of users
    /// </summary>
    internal class Data : IData
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]);

        /// <summary>
        /// A method to check wheather user is available or not
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUser(string userName)
        {
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select USERNAME from " + ConfigurationManager.AppSettings["Table"] + " where USERNAME='" + userName + "';";
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    con.Close();
                    return true;
                }
            }
            con.Close();
            return false;
        }

        /// <summary>
        /// A method to store user details. If sucessful returns True
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public bool StoreData(RegisterModel modelObject)
        {
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "INSERT INTO " + ConfigurationManager.AppSettings["Table"] + "(USERNAME,PASSWORD,PhoneNo) VALUES('" + modelObject.userName + "','" + modelObject.password + "','" + modelObject.phoneNo + "'); ";
            try
            {
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }

        /// <summary>
        /// a method to return password if details provided are correct
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public string GetPassword(ForgotPasswordModel modelObject)
        {
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select USERNAME,PASSWORD,PhoneNo from " + ConfigurationManager.AppSettings["Table"] + " where USERNAME='" + modelObject.userName + "';";
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (modelObject.phoneNo == reader[2].ToString())
                    {
                        string temp = reader[1].ToString();
                        con.Close();
                        return temp;
                    }
                    else
                    {
                        con.Close();
                        return null;
                    }
                }

            }
            con.Close();
            return null;
        }

        /// <summary>
        /// A method to verify password and logIn the user
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public bool LogInCheck(LogInModel modelObject)
        {
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select USERNAME,PASSWORD from " + ConfigurationManager.AppSettings["Table"] + " where USERNAME='" + modelObject.userName + "';";
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (modelObject.password == reader[1].ToString())
                    {
                        con.Close();
                        return true;
                    }

                }
            }
            con.Close();
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public void LogEvent(EventLog modelObject)
        {
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            string table = ConfigurationManager.AppSettings["Log"];
            if (modelObject.Type == LogType.EXCEPTION)
            {
                table = ConfigurationManager.AppSettings["ErrorLog"];
            }
            command.CommandText = "INSERT INTO " + table + "(Type,UserName,Event) VALUES(" + (int)modelObject.Type + ",'" + modelObject.userName + "','" + modelObject.Event + "'); ";
            try
            {
                command.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
    }
}
