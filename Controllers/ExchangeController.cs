using BusinessApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace BusinessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly MoneyContext dbContext;
        string query;
        MySqlCommand cmd;
        MySqlDataReader myReader;
        public ExchangeController(MoneyContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet]
        [Route("GetExchangeRate")]
        public List<KeyValuePair<String, String>> GetExchangeRate(string CurrencyCode)
        {
            List<KeyValuePair<String, String>> items = new List<KeyValuePair<String, String>>();
            //System.Diagnostics.Debug.WriteLine("burda "+CurrencyCode.Length);
            try
            {
                if (CurrencyCode.Length == 3)
                {
                    CurrencyCode = CurrencyCode.ToUpper();
                    //System.Diagnostics.Debug.WriteLine("ilk if");
                    MySqlConnection conn = new MySqlConnection("server = 127.0.0.1; database = prodb; user id = root; password = root");
                    conn.Open();
                    //System.Diagnostics.Debug.WriteLine(conn.State);
                    if (conn.State == ConnectionState.Open)
                    {
                        //System.Diagnostics.Debug.WriteLine("query "+CurrencyCode);
                        //query = "SELECT * FROM prodb.currencies WHERE Kod='"+CurrencyCode+"' IN (SELECT * FROM prodb.tarih_dates WHERE Tarih_DatetrID='trId';";
                        query = "SELECT* FROM prodb.currencies INNER JOIN prodb.tarih_dates ON Tarih_DatetrId = trID WHERE Kod ='"+CurrencyCode+"';";
                        cmd = conn.CreateCommand();
                        cmd.CommandText = query;
                        myReader = cmd.ExecuteReader();
                
                        while (myReader.Read())
                        {
                            //System.Diagnostics.Debug.WriteLine("reading data");
                            items.Add(new KeyValuePair<String, String>("Kod", myReader.GetString(11)));
                            items.Add(new KeyValuePair<String, String>("ForexSel", myReader.GetString(5)));
                            items.Add(new KeyValuePair<String, String>("ForexBuy", myReader.GetString(4)));
                            items.Add(new KeyValuePair<String, String>("Tarih", myReader.GetString(15)));
                        }
                        conn.Close();
                        return items;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return items;
        }
    }
}
