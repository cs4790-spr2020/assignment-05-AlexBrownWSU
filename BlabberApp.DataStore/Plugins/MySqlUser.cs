using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class MySqlUser : IPlugin
    {
        MySqlConnection dcUser;
        public MySqlUser()
        {
            this.dcUser = new MySqlConnection("server=142.93.114.73;database=donbstringham;user=donbstringham;password=letmein");
            try
            {
                this.dcUser.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public void Close()
        {
            this.dcUser.Close();
        }
        public void Create(IEntity obj)
        {
            User user = (User)obj;
            try
            {
                DateTime now = DateTime.Now;
                string sql = "INSERT INTO users (sys_id, email, dttm_registration, dttm_last_login) VALUES ('"
                     + user.Id + "', '"
                     + user.Email + "', '"
                     + now.ToString("yyyy-MM-dd HH:mm:ss")
                     + "', '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.dcUser);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable ReadAll()
        {
            return null;
        }

        public IEntity ReadById(Guid Id)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE users.sys_id = '" + Id.ToString() + "'";
                Console.WriteLine(sql);
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, this.dcUser); // To avoid SQL injection.
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();

                daUser.Fill(dsUser, "users");

                DataRow row = dsUser.Tables[0].Rows[0];
                User user = new User();

                user.Id = new Guid(row["sys_id"].ToString());
                user.ChangeEmail(row["email"].ToString());
                user.RegisterDTTM = (DateTime)row["dttm_registration"];
                user.LastLoginDTTM = (DateTime)row["dttm_last_login"];

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Update(IEntity obj)
        {
            User user = (User)obj;
        }

        public void Delete(IEntity obj)
        {
            User user = (User)obj;
        }
    }
}