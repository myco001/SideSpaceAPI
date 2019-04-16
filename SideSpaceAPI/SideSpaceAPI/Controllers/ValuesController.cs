using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace SideSpaceAPI.Controllers
{
    public class Results
    {
        public string HName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Mental { get; set; }
        public string Error { get; set; }

        public Results(string HName, string Address, string Suburb, string Postcode, string Lat, string Lon, string Mental, string Error)
        {
            this.HName = HName;
            this.Address = Address;
            this.Suburb = Suburb;
            this.Postcode = Postcode;
            this.Lat = Lat;
            this.Lon = Lon;
            this.Mental = Mental;
            this.Error = Error;
        }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Results> Get()
        {
            // Create connection
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM hospital;";

            var results = new List<Results>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Results(null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new Results(fetch_query["HName"].ToString(),
                    fetch_query["Address"].ToString(),
                    fetch_query["Suburb"].ToString(),
                    fetch_query["Postcode"].ToString(),
                    fetch_query["Lat"].ToString(),
                    fetch_query["Lon"].ToString(),
                    fetch_query["Mental"].ToString(),
                    null));
            }

            return results;
        }

        // GET api/values/5
        public List<Results> Get(int ID)
        {
            // Create connection
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM hospital WHERE ID = @ID;";

            query.Parameters.AddWithValue("@ID", ID);

            var results = new List<Results>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Results(null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new Results(fetch_query["HName"].ToString(),
                    fetch_query["Address"].ToString(),
                    fetch_query["Suburb"].ToString(),
                    fetch_query["Postcode"].ToString(),
                    fetch_query["Lat"].ToString(),
                    fetch_query["Lon"].ToString(),
                    fetch_query["Mental"].ToString(),
                    null));
            }
            return results;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class MentalController : ApiController
    {
        // GET api/mental
        public List<Results> Get()
        {
            // Create connection
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM hospital WHERE Mental = 'Y';";

            var results = new List<Results>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Results(null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new Results(fetch_query["HName"].ToString(),
                    fetch_query["Address"].ToString(),
                    fetch_query["Suburb"].ToString(),
                    fetch_query["Postcode"].ToString(),
                    fetch_query["Lat"].ToString(),
                    fetch_query["Lon"].ToString(),
                    fetch_query["Mental"].ToString(),
                    null));
            }

            return results;
        }
    }

    public class PostcodeController : ApiController
    {
        // GET api/values
        public List<Results> Get(string postcode)
        {
            // Create connection
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM hospital WHERE postcode = @postcode;";

            query.Parameters.AddWithValue("@postcode", postcode);

            var results = new List<Results>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Results(null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new Results(fetch_query["HName"].ToString(),
                    fetch_query["Address"].ToString(),
                    fetch_query["Suburb"].ToString(),
                    fetch_query["Postcode"].ToString(),
                    fetch_query["Lat"].ToString(),
                    fetch_query["Lon"].ToString(),
                    fetch_query["Mental"].ToString(),
                    null));
            }

            return results;
        }
    }

    public class SuburbController : ApiController
    {
        // GET api/values
        public List<Results> Get(string suburb)
        {
            // Create connection
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM hospital WHERE suburb = @suburb;";

            query.Parameters.AddWithValue("@suburb", suburb);

            var results = new List<Results>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Results(null, null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new Results(fetch_query["HName"].ToString(),
                    fetch_query["Address"].ToString(),
                    fetch_query["Suburb"].ToString(),
                    fetch_query["Postcode"].ToString(),
                    fetch_query["Lat"].ToString(),
                    fetch_query["Lon"].ToString(),
                    fetch_query["Mental"].ToString(),
                    null));
            }

            return results;
        }
    }
}
