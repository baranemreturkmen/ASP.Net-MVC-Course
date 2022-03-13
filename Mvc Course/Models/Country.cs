using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Course.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public static List<Country> GetFakeCountries()
        {
            return new List<Country>()
            {
                new Country() { CountryId = 0, CountryName = "England" },
                new Country() { CountryId = 1, CountryName = "USA" },
                new Country() { CountryId = 2, CountryName = "Germany" },
                new Country() { CountryId = 3, CountryName = "Turkey" },
                new Country() { CountryId = 4, CountryName = "France" }
            };
        }
    }
}