using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace inventio_win{
    class Connection{
        public MySqlConnection con;
        public long insert_id;
        //Aun falta poder agregarle los datos a la base
        public Connection() {
            try
            {
                MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
                b.Server = "localhost";
                b.UserID = "root";//usuario que tenes registrado en tu base de datos mysql, no vayas a ocupar xampp que no sirve
                b.Password = "140799Daoo";//contrasenia que le pusiste a la base de datos de mysql
                b.Database = "inventario";
                con = new MySqlConnection(b.ToString());
            }
            catch (MySqlException me) {
                MessageBox.Show(me.Message);
            }
        }

        public void execute(String sql){
            MySqlCommand cmd = this.con.CreateCommand();
            cmd.CommandText = sql;
            this.con.Open();
            cmd.ExecuteNonQuery();
            this.con.Close();
            this.insert_id = cmd.LastInsertedId;
        }

        public int GetInt(String sql)//Usar funcion para sacar cualquier entero que se necesite
        {
            int Int;
            MySqlCommand cmd = this.con.CreateCommand();
            cmd.CommandText = sql;
            this.con.Open();
            Int = cmd.ExecuteNonQuery();
            this.con.Close();
            return Int;
        }

        public void Coneccion(String User, String Password){
            try
            {
                MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
                b.Server = "localhost";
                b.UserID = User;//usuario que tenes registrado en tu base de datos mysql, no vayas a ocupar xampp que no sirve
                b.Password = Password;//contrasenia que le pusiste a la base de datos de mysql
                b.Database = "Proyecto";
                con = new MySqlConnection(b.ToString());
            }
            catch (MySqlException me)
            {
                MessageBox.Show(me.Message);
            }
        }
    }
}
