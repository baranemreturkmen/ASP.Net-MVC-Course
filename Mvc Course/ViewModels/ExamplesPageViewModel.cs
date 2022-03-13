using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.ViewModels
{
    public class ExamplesPageViewModel
    {
        //Model üzerinden o sayfada neyi doldurmak istiyorum yada neyi almaya çalışıyorum bunun için gerekli propertylerim neler?
        public int SelectedCityId { get; set; }
        public int SelectedCountryId { get; set; }
        //Yukarıdaki propertyler bana sayfamda dönecek sonuçları verecek.


        public SelectList  CitiesData { get; set; }
        public SelectList CountriesData { get; set; }
        //Yukarıdaki propertyler ile sayfamda DropDownListleri dolduracağım.
    }
}