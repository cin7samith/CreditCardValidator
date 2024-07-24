using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator.Common.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CreditCardValidator.Data.Models;

namespace CreditCardValidator.Data.Repositories
{
    public class CardTypeInfoRepository: ICardTypeInfoRepository
    {     

        public List<ICardTypeInfo> GetAll()
        {
            string CS = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;            

            List<ICardTypeInfo> cardInfoList = new List<ICardTypeInfo>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GetCardTypeInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                        
                        string id = reader["Id"].ToString();
                        string name = reader["Name"].ToString();
                        string digits = reader["Digits"].ToString();
                        string regex = reader["Regex"].ToString();
                        
                        CardTypeInfo cardInfo = new CardTypeInfo
                        {
                            Id=Convert.ToInt32(id),
                            Name = name,
                            Digits = Convert.ToInt32(digits),
                            RegEx = regex
                        };

                        cardInfoList.Add(cardInfo);
                    }
                }
            }
            return cardInfoList;
        }

    }
}
