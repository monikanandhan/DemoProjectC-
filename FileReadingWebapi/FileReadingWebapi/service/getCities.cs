using CsvHelper;
using FileReadingWebapi.Model;
using System.Configuration;
using System.Formats.Asn1;

namespace FileReadingWebapi.service
{
    public class getCities
    {
        public CitiesDbContext context { get; set; }
        public getCities(CitiesDbContext _context)
        {
            context = _context;

        }

        public void GetAllcitiesAsList(Cities cities)
        {
            string fpath = @"worldcities.csv";
            using var fileReader = File.OpenText(fpath);
            var config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture);
                config.MissingFieldFound = null;
           
            using (var csvReader = new CsvReader(fileReader, config))
            {
                csvReader.Read();
                csvReader.ReadHeader();                
                var users = csvReader.GetRecords<Cities>();
                
                foreach (var item in users)
                {
                    var NewCities = new Cities()
                    {
                        Id= item.Id,
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
                    context.cities.Add(NewCities);
                    context.SaveChanges();
                }
            }
        }
        }
    }

//city = users.ToList().First().city,
//city_ascii = users.ToList().First().city_ascii,
//lat = users.ToList().First().lat,
//lng = users.ToList().First().lng,
//country = users.ToList().First().country,
//iso2 = users.ToList().First().iso2,
//iso3 = users.ToList().First().iso3,
//admin_name = users.ToList().First().admin_name,
//capital = users.ToList().First().capital,
//population = users.ToList().First().population,
//citiesno = users.ToList().First().citiesno