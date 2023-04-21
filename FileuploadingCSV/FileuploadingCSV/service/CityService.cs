using CsvHelper;
using FileuploadingCSV.Model;
using System.Formats.Asn1;
using System.Globalization;

namespace FileuploadingCSV.service
{
    public class CityService
    {
        public CitiesDemoDbContext context { get; set; }    
        public CityService(CitiesDemoDbContext _context) 
        { 
            context = _context;
        }

        public IEnumerable<Cities>  AddAllDetails(Stream file)
        {
            var reader = new StreamReader(file);
            var config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture);
            config.MissingFieldFound = null;

            var csv = new CsvReader(reader, config);
            
                csv.Read();
                csv.ReadHeader();
                var records = csv.GetRecords<Cities>();

            //List<Cities> list = new List<Cities>();

            foreach (var item in records)
            {
                var NewCities = new Cities()
                {
                    Id = item.Id,
                    city = item.city,
                    city_ascii = item.city_ascii,
                    lat = item.lat,
                    lng = item.lng,
                    country = item.country,
                    iso2 = item.iso2,
                    iso3 = item.iso3,
                    admin_name = item.admin_name,
                    capital = item.capital,
                    population = item.population,
                    citiesno = item.citiesno

                };

                //    list.Add(NewCities);

                //}
                //context.cities.AddRange(list);
                context.cities.Add(NewCities);
                context.SaveChanges();
            }
                return records;
            

            
            
        }
    }
}
