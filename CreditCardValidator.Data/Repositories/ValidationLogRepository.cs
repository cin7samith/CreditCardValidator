using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator.Common.Interfaces;

namespace CreditCardValidator.Data.Repositories
{
    public class ValidationLogRepository : IValidationLogRepository
    {
        public bool Add(string cardNumber, bool status, string message, DateTime createDateTime)
        {
            string CS = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_InsertValidationLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Message", message);
                cmd.Parameters.AddWithValue("@CreateDateTime", createDateTime);

                con.Open();
                int effectedRows=cmd.ExecuteNonQuery();

                if(effectedRows > 0)
                return true;
                else
                return false;
            }   
        }
    }
}
