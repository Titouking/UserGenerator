using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UsersGenerator.Clients
{
    public class UserGenResponse
    {
        [JsonPropertyName("results")]
        public User[] Results { get; set; }

        public class User
        {
            [JsonPropertyName("gender")]
            public string Gender { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("name")]
            public Name FullName { get; set; }

            [JsonPropertyName("location")]
            public Location Location { get; set; }

            [JsonPropertyName("picture")]
            public Pictures Pictures { get; set; }

            [JsonPropertyName("dob")]
            public Birthday Birthday { get; set; }

            [JsonPropertyName("phone")]
            public string Phone { get; set; }

            [JsonPropertyName("cell")]
            public string Mobile { get; set; }

            [JsonPropertyName("login")]
            public Credentials Credentials { get; set; }
        }

        public class Name
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("first")]
            public string First { get; set; }

            [JsonPropertyName("last")]
            public string Last { get; set; }
        }

        public class Location
        {
            [JsonPropertyName("street")]
            public StreetDetail Street { get; set; }

            [JsonPropertyName("city")]
            public string City { get; set; }

            [JsonPropertyName("state")]
            public string State { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("postcode")]
            public int PostalCode { get; set; }
        }

        public class StreetDetail
        {
            [JsonPropertyName("number")]
            public int StreetNumber { get; set; }

            [JsonPropertyName("name")]
            public string StreetName { get; set; }
        }

        public class Pictures
        {
            [JsonPropertyName("large")]
            public string Large { get; set; }

            [JsonPropertyName("medium")]
            public string Medium { get; set; }

            [JsonPropertyName("thumbnail")]
            public string Small { get; set; }
        }

        public class Birthday
        {
            [JsonPropertyName("date")]
            public string Date { get; set; }

            [JsonPropertyName("age")]
            public int Age { get; set; }
        }

        public class Credentials
        {
            [JsonPropertyName("uuid")]
            public string Uid { get; set; }

            [JsonPropertyName("username")]
            public string Username { get; set; }

            [JsonPropertyName("password")]
            public string Password { get; set; }

            [JsonPropertyName("salt")]
            public string Salt { get; set; }

            [JsonPropertyName("md5")]
            public string Md5 { get; set; }

            [JsonPropertyName("sha1")]
            public string Sha1 { get; set; }

            [JsonPropertyName("sha256")]
            public string Sha256 { get; set; }
        }

    }
}
