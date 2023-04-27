using CsvHelper;
using Microsoft.Extensions.Hosting;
using System.Formats.Asn1;

namespace FileCSVReaderDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fpath = @"worldcities.csv";
            using var streamReader = File.OpenText(fpath);
            using var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.CurrentCulture);
            var cities = csvReader.GetRecords<WorldCities>();



            // foreach (var user in users)
            // {
            //     Console.WriteLine(user);
            // }

            //1.Unique cities
            List<string> UniqueCities = cities.Select(x => x.city).Distinct().ToList();
            foreach (var UniqCity in UniqueCities)
            {
                Console.WriteLine(UniqCity);
            }


            //2.Total no of cities
            //int TotalCities = cities.Select(x => x.city).Distinct().Count();
            //Console.WriteLine(TotalCities);


            //3.Country wise city count
            //var CityCount = cities.GroupBy(x => x.country);
            //foreach (var CountryCitiesCount in CityCount)
            //{
            //    Console.WriteLine("\t");
            //    Console.WriteLine(CountryCitiesCount.Key + " " + CountryCitiesCount.Count());
            //    foreach (var result in CountryCitiesCount)
            //    {
            //        Console.WriteLine(result.city);
            //    }
            //}




            //4.city names in same lat

            //var SameLat = cities.GroupBy(x => x.lat);
            //foreach (var item in SameLat)
            //{
            //    Console.WriteLine("\t");
            //    Console.WriteLine(item.Key + " " + item.Count());
            //    foreach (var CitySameLat in item)
            //    {
            //        Console.WriteLine(CitySameLat.city);
            //    }
            //}



            //5.Cities in same lng

            //var NewLng = cities.GroupBy(x => x.lng);
            //foreach (var item in NewLng)
            //{
            //    Console.WriteLine("\t");
            //    Console.WriteLine(item.Key + " " + item.Count());
            //    foreach (var sameLng in item)
            //    {
            //        Console.WriteLine(sameLng.city);
            //    }
            //}



            //6.Order cities by population
            //var population = cities.OrderBy(x => x.population);
            //foreach (var PopOrder in population)
            //{
            //    Console.WriteLine(PopOrder.city + " " + PopOrder.population);
            //}



            //7.Country wise State count

            //var State = cities.GroupBy(x => x.country);
            //foreach (var item in State)
            //{

            //    Console.WriteLine(item.Key + " " + item.Count());
            //    foreach (var CountryStateCount in item)
            //    {
            //        Console.WriteLine(CountryStateCount.admin_name);
            //    }
            //}



            //8.State wise city count
            //        var city = cities.GroupBy(x => x.admin_name);
            //        foreach (var item in city)
            //        {
            //            Console.WriteLine(item.Key + " " + item.Count());
            //            foreach (var StateCityCount in item)
            //            {
            //                Console.WriteLine(StateCityCount.city);
            //            }
            //        }




            //9.Search my city

            //Console.WriteLine("Enter the city");
            //string str = Console.ReadLine();
            //Console.WriteLine(str);
            //string[] cityResult = cities.Select(x => x.city).ToArray();

            //int count = 0;
            //for (int i = 0; i < cityResult.Count(); i++)
            //{


            //    if (cityResult.Contains(str))
            //    {
            //        count++;

            //    }
            //}
            //if (count > 0)
            //{
            //    Console.WriteLine(str);
            //}
            //else
            //{
            //    Console.WriteLine("No such cities found");
            //}

            //Console.ReadLine();





            //10.List Unique capital
            //List<string> UniqCapital = cities.Select(x => x.capital).Distinct().ToList();
            //foreach (var CapitalUniq in UniqCapital)
            //{
            //    Console.WriteLine(CapitalUniq);
            //}



            //11.upper case / lowercase

            //List<string> UpperResult = cities.Select(x => x.city).ToList();

            //foreach (var UpperCity in UpperResult)
            //{
            //    Console.WriteLine(UpperCity.ToUpper());
            //}

            //List<string> LowerResult = cities.Select(x => x.city).ToList();

            //foreach (var LowerCity in LowerResult)
            //{
            //    Console.WriteLine(LowerCity.ToLower());
            //}



            //12.String to double/float

            //IEnumerable<string> TypeConversion = cities.Select(x => x.population);
            //double result;
            //foreach (var TypeChange in TypeConversion)
            //{
            //    try
            //    {
            //        result = Double.Parse(TypeChange);
            //        Console.WriteLine(result);
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("0",
            //        TypeChange.GetType().Name, TypeChange);

            //    }
            //}


            // 13. Show only 3 values for lat/ lng
            //IEnumerable<string> TrimValues = cities.Select(x => x.lat).Take(3);

            //foreach (var LatLngValues in TrimValues)
            //{

            //    Console.WriteLine(LatLngValues);
            //}



            //14.Print country name in A-Z
            //List<WorldCities> CountryName = cities.OrderBy(x => x.country).ToList();
            //for (int i = 0; i < CountryName.Count(); i++)
            //{
            //    Console.WriteLine(CountryName[i].country);
            //}



            //15.duplicate cities

            //List<string> CitiesResult = cities.GroupBy(x => x.city).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

            //foreach (var dupliacteCities in CitiesResult)
            //{
            //    Console.WriteLine(dupliacteCities);
            //}


            //16.print the cities ending with "ing"

            //List<WorldCities> CitiesWithing = cities.OrderBy(x => x.city.EndsWith("ing")).ToList();
            //foreach (var CitiesName in CitiesWithing)
            //{
            //    Console.WriteLine(CitiesName.city);
            //}



            //17.Remove the space from City "New York" as NewYork
            //var RemoveSpace = String.Join("", "New York".Split(" "));

            //Console.WriteLine(RemoveSpace);


        }
    }
}
