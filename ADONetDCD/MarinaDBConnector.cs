using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDCD
{
    class MarinaDBConnector
    {
        private SqlConnection dbSqlConnection;
        //private bool dbConnectionIsPersistent = true;
        
        //public string dbConnectionString { get; set; }

        public MarinaDBConnector(string dbConnectionString)
        {
            try
            {
                //Open connection set it to dbSqlConnection
                dbSqlConnection = new SqlConnection(dbConnectionString);
                dbSqlConnection.Open();
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ~MarinaDBConnector()
        {
            //Close the connection
            dbSqlConnection.Close();
        }

        /// <summary>
        /// Selects an individual MarinaDBRow from Marina table
        /// </summary>
        /// <param name="id">Id of the requested record</param>
        /// <returns>MarinaDBRow Object</returns>
        public MarinaDBRow Select(string id)
        {
            //stub
            String sqlQueryString = "SELECT marina_num, name, address, city, state, zip FROM marina WHERE marina_num = " + id + ";";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            MarinaDBRow row = new MarinaDBRow();

            if (reader.Read())
            {
                row.id = reader[0].ToString().Trim();
                row.name = reader[1].ToString().Trim();
                row.address = reader[2].ToString().Trim();
                row.city = reader[3].ToString().Trim();
                row.state = reader[4].ToString().Trim();
                row.zip = reader[5].ToString().Trim();
            }
            reader.Close();
            return row;
        }

        /// <summary>
        /// Inserts a MarinaDBRow into the Marina table
        /// </summary>
        /// <param name="?">MarinaDBRow to be inserted</param>
        /// <returns>Number of records affected in the Marina table</returns>
        public int Insert(MarinaDBRow row)
        {
            //stub
            return Insert(row.id,row.name,row.address,row.city,row.state,row.zip);
        }

        /// <summary>
        /// Inserts data into the Marina table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns>Number of records affected in the Marina table</returns>
        public int Insert(string id, string name, string address, string city, string state, string zip)
        {
            //stub
            String sqlQueryString = "INSERT INTO marina VALUES ('" + id + "', '" + name + "','" + address + "','" + city + "', '" + state + "', '" + zip + "' );";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }
        
        /// <summary>
        /// Updates a Marina record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns>Number of records affected in the Marina table</returns>
        public int Update(string id, string name, string address, string city, string state, string zip)
        {
            //stub
            String sqlQueryString = "UPDATE marina SET name = '" + name + "', address ='" + address + "', city ='" + city + "', state = '" + state + "', zip ='" + zip + "' WHERE marina_num = '" + id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates a Marina record
        /// </summary>
        /// <param name="oldId">Id value to change</param>
        /// <param name="newId">Updated id value</param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns>Number of records affected in the Marina table</returns>
        public int Update(string oldId, string newId, string name, string address, string city, string state, string zip)
        {
            //stub
            String sqlQueryString = "UPDATE marina SET marina_num = '"+newId+"', name = '" + name + "', address ='" + address + "', city ='" + city + "', state = '" + state + "', zip ='" + zip + "' WHERE marina_num = '" + oldId + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates a Marina record
        /// </summary>
        /// <param name="id">Id value to change</param>
        /// <param name="row"></param>
        /// <returns>Number of records affected in the Marina table</returns>
        public int Update(string id, MarinaDBRow row)
        {
            //stub
            String sqlQueryString = "UPDATE marina SET name = '" + row.name + "', address ='" + row.address + "', city ='" + row.city + "', state = '" + row.state + "', zip ='" + row.zip + "' WHERE marina_num = '" + row.id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes a record in the Marina Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of record affected in the Marina table</returns>
        public int Delete(string id)
        {
            //stub
            String sqlQueryString = "DELETE FROM Marina WHERE marina_num = '" + id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
