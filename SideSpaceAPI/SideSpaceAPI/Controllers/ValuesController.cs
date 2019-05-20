using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace SideSpaceAPI.Controllers
{
    //Store results for hospital.(Used in Iteration 1 and 2)
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

    //Store results for hospitals with private and placeid info.(Used in Iteration 3 and forward)
    public class Hospitals
    {
        public string HName { get; set; }
        public string Postcode { get; set; }
        public string Type { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string PlaceID { get; set; }
        public string Error { get; set; }

        public Hospitals(string HName, string Postcode, string Type, string Lat, string Lng, string PlaceID, string Error)
        {
            this.HName = HName;
            this.Postcode = Postcode;
            this.Type = Type;
            this.Lat = Lat;
            this.Lng = Lng;
            this.PlaceID = PlaceID;
            this.Error = Error;
        }
    }

    // Controller for get only public hospitals' info. (Used in Iteration 1 and 2)
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
    }

    //Controller to get hospitals' info with mental service.(Used in Iteration 1)
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

    // Controller for getting updated hospitals' info (with private and placeid). (Used in Iteration 3 and forward)
    public class HospitalController : ApiController
    {
        // GET api/values
        public List<Hospitals> Get()
        {
            // Create connection
            MySqlConnection conn = WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM hospital2;";

            var hospitals = new List<Hospitals>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                hospitals.Add(new Hospitals(null, null, null, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                hospitals.Add(new Hospitals(fetch_query["HName"].ToString(),
                    fetch_query["Postcode"].ToString(),
                    fetch_query["Type"].ToString(),
                    fetch_query["Lat"].ToString(),
                    fetch_query["Lng"].ToString(),
                    fetch_query["PlaceID"].ToString(),
                    null));
            }

            return hospitals;
        }
    }
}
