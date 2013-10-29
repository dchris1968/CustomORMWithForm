using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDCD
{
    //Active record pattern

    class Marina
    {
        public string id;
        public string name;
        public string address;
        public string city;
        public string state;
        public string zip;

        public int Update()
        {
            SqlConnection dbSqlConnection = new SqlConnection(Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            String sqlQueryString = "UPDATE marina SET marina_num = '" + this.id + "', name = '" + this.name + "', address ='" + this.address + "', city ='" + this.city + "', state = '" + this.state + "', zip ='" + this.zip + "' WHERE marina_num = '" + this.id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            int numRowsAffected = sqlCommand.ExecuteNonQuery();

            dbSqlConnection.Close();

            return numRowsAffected;
        }

        public int Delete()
        {
            SqlConnection dbSqlConnection = new SqlConnection(Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();
            
            String sqlQueryString = "DELETE FROM Marina WHERE marina_num = '" + this.id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            int numRowsAffected = sqlCommand.ExecuteNonQuery();

            dbSqlConnection.Close();

            return numRowsAffected;
        }

        public static Marina GetMarinaById(string id)
        {
            //stub    
            SqlConnection dbSqlConnection = new SqlConnection(Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            String sqlQueryString = "SELECT marina_num, name, address, city, state, zip FROM marina WHERE marina_num = " + id + ";";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Marina row = new Marina();
            
            reader.Read();

            row.id = reader[0].ToString().Trim();
            row.name = reader[1].ToString().Trim();
            row.address = reader[2].ToString().Trim();
            row.city = reader[3].ToString().Trim();
            row.state = reader[4].ToString().Trim();
            row.zip = reader[5].ToString().Trim();

            reader.Close();
            dbSqlConnection.Close();
            return row;        
        }

        public static List<Marina> GetAllMarinas()
        {
            SqlConnection dbSqlConnection = new SqlConnection(Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            String sqlQueryString = "SELECT marina_num, name, address, city, state, zip FROM marina;";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Marina> marinas = new List<Marina>();

            while (reader.Read())
            {
                Marina row = new Marina();
                row.id = reader[0].ToString().Trim();
                row.name = reader[1].ToString().Trim();
                row.address = reader[2].ToString().Trim();
                row.city = reader[3].ToString().Trim();
                row.state = reader[4].ToString().Trim();
                row.zip = reader[5].ToString().Trim();
                marinas.Add(row);
            }
            reader.Close();
            return marinas;
        }
    }
}
