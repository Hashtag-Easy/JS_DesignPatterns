using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples
{
    internal class IteratorPatternSample
    {

        public void Test()
        {
            using (var conn = new SqlConnection(""))
            {
                var command = conn.CreateCommand();


                var reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    var colId = reader.GetString("id");
                    var colName = reader["name"];
                }

            }
        }
    }
}
