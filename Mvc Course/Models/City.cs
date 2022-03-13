using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Course.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public static List<City> GetFakeCities()
        {
            return new List<City>()
            {
                new City() {CityId = 10, CityName = "Leicester", CountryId=0},
                new City() {CityId = 11, CityName = "Dallas", CountryId=1},
                new City() {CityId = 12, CityName = "Münih", CountryId=2},
                new City() {CityId = 13, CityName = "Ankara", CountryId=3},
                new City() {CityId = 14, CityName = "Paris", CountryId=4},
            };
        }
    }
}