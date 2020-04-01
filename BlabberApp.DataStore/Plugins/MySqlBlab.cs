using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class MySqlBlab : IPlugin
    {
        MySqlConnection dcBlab;
        public MySqlBlab()
        {
            this.dcBlab = new MySqlConnection("server=142.93.114.73;database=donbstringham;user=donbstringham;password=letmein");
            try
            {
                this.dcBlab.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public void Close()
        {
            this.dcBlab.Close();
        }
        public void Create(IEntity obj)
        {
            Blab blab = (Blab)obj;
            try
            {
                DateTime now = DateTime.Now;
                string sql = "INSERT INTO users (sys_id, message, dttm_created, user_id) VALUES ('"
                     + blab.Id + "', '"
                     + blab.Message + "', '"
                     + now.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                     + blab.User.Email + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.dcBlab);
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
                string sql = "SELECT * FROM blabs WHERE blabs.sys_id = '" + Id.ToString() + "'";
                Console.WriteLine(sql);
                MySqlDataAdapter daBlab = new MySqlDataAdapter(sql, this.dcBlab); // To avoid SQL injection.
                MySqlCommandBuilder cbBlab = new MySqlCommandBuilder(daBlab);
                DataSet dsBlab = new DataSet();

                daBlab.Fill(dsBlab, "blabs");

                DataRow row = dsBlab.Tables[0].Rows[0];
                Blab blab = new Blab();

                blab.Id = new Guid(row["sys_id"].ToString());

                return blab;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Update(IEntity obj)
        {
            Blab blab = (Blab)obj;
        }

        public void Delete(IEntity obj)
        {
            Blab blab = (Blab)obj;
        }
    }
}