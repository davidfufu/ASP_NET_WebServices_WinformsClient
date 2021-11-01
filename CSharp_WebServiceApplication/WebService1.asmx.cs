using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace CSharp_WebServiceApplication
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DBAccess objDBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        DataTable dtCountries = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Sum(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public string Countries()
        {
            dtCountries.Columns.Add("CountryName");
            dtCountries.Columns.Add("Continent");

            dtCountries.Rows.Add("Pakistan", "Asia");
            dtCountries.Rows.Add("India", "Asia");
            dtCountries.Rows.Add("Germany", "Europe");
            dtCountries.Rows.Add("SriLanka", "Asia");
            dtCountries.Rows.Add("Australia", "Australia");
            dtCountries.Rows.Add("New Zealand", "AsAustraliaia");

            return JsonConvert.SerializeObject(dtCountries);

        }

        [WebMethod]
        public string dataTableForUsers(string id)
        {
            string query = $"Select * From Users Where ID = '{id}'";
            objDBAccess.readDatathroughAdapter(query, dtUsers);

            string result = JsonConvert.SerializeObject(dtUsers);
            return result;


        }
    }
}
