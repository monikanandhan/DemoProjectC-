using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using CsvHelper;

namespace FileCSVReading
{
    class Program
    {
        static void Main(string[] args)
        {
            string fpath = @"worldcities.csv";
            using var streamReader = File.OpenText(fpath);
            using var csvReader = new CsvReader(streamReader);
            var users = csvReader.GetRecords<Demo>();



            // foreach (var user in users)
            // {
            //     Console.WriteLine(user);
            // }
            1.Unique cities
                 List<string> DemoNew = users.Select(x => x.city).Distinct().ToList();
            foreach (var user in DemoNew)
            {
                Console.WriteLine(user);
            }
            //2.Total no of cities
            // int DemoNews = users.Select(x => x.city).Distinct().Count();
            // Console.WriteLine(DemoNews);

            //3.Country wise city count
            //  var NewDemo= users.GroupBy(x=>x.country);
            //     foreach (var item in NewDemo)
            //     {  
            //          Console.WriteLine("\t");  
            //         Console.WriteLine(item.Key+" "+item.Count());
            //         foreach (var items in item)
            //         {
            //             Console.WriteLine(items.city);
            //         }
            //     }
            //4.city names in same lat

            // var NewDemo= users.GroupBy(x=>x.lat);
            //                 foreach (var item in NewDemo)
            //                 {  
            //                      Console.WriteLine("\t");  
            //                     Console.WriteLine(item.Key+" "+item.Count());
            //                     foreach (var items in item)
            //                     {
            //                         Console.WriteLine(items.city);
            //                     }
            //                 }

            //5.Cities in same lng

            // var NewLng=users.GroupBy(x=>x.lng);
            // foreach (var item in NewLng)
            // {
            //     Console.WriteLine("\t");
            //     Console.WriteLine(item.Key+" "+item.Count());
            //     foreach (var items in item)
            //     {
            //         Console.WriteLine(items.city);
            //     }
            // }

            //6.Order cities by population
            // var m=users.OrderBy(x=>x.population).ThenBy(x=>x.city);
            // foreach (var item in m)
            // {
            //     Console.WriteLine(item.city+" "+item.population);
            // }

            //7.Country wise State count

            // var d=users.GroupBy(x=>x.country);
            // foreach (var item in d)
            // {

            //     Console.WriteLine(item.Key+" "+item.Count());
            //     foreach (var items in item)
            //     {
            //         Console.WriteLine(items.admin_name);
            //     }
            // }

            //8.State wise city count
            // var s=users.GroupBy(x=>x.admin_name);
            // foreach (var item in s)
            // {
            //     Console.WriteLine(item.Key+" "+item.Count());
            //     foreach (var items in item)
            //     {
            //         Console.WriteLine(items.city);
            //     }
            // }

            //9.Less populated city
            // IEnumerable<string>  pop = users.Select(x => x.population);
            //      double result;
            // foreach (var item in pop)
            // {
            //     try{
            // result =Double.Parse(item);
            // Console.WriteLine(result);

            //     }
            //      catch (FormatException) {
            //     Console.WriteLine("0",
            //     item.GetType().Name, item);


            // }
            // }


            //10.Search my city
            // Console.WriteLine("Enter the city");
            // string str = Console.ReadLine();
            // Console.WriteLine(str);
            // string[] demo = users.Select(x => x.city).ToArray();

            // int count = 0;
            // for (int i = 0; i < demo.Count(); i++)
            // {


            //     if (demo.Contains(str))
            //     {
            //         count++;

            //     }
            // }
            // if (count > 0)
            // {
            //     Console.WriteLine(str);
            // }
            // else
            // {
            //     Console.WriteLine("No such cities found");
            // }

            // Console.ReadLine();




            // 11.Search by city and display nearer city

            // Console.WriteLine("Enter the city");
            // string str = Console.ReadLine();
            // Console.WriteLine(str);

            // string[] demo = users.Select(x => x.city).ToArray();
            //  string[] demos = users.Select(x => x.country).ToArray();

            // int count = 0;
            // for (int i = 0; i < demo.Count(); i++)
            // {
            //     if (demo[i].Contains(str))
            //     {
            //         count++;
            //         Console.WriteLine(i);

            //         break;

            //     }

            // }
            // if (count > 0)
            // {
            //     Console.WriteLine("true");
            // }
            // else
            // {
            //     Console.WriteLine("No such cities found");
            // }

            // Console.ReadLine();
            // bool NewDemo = users.GroupBy(x => x.city).Equals(str);
            // Console.WriteLine(NewDemo);
            // foreach (var item in NewDemo)
            //                  {  
            //                       Console.WriteLine("\t");  
            //                      Console.WriteLine((item.Key+" "+item.Count()));
            //                      foreach (var items in item)
            //                      {
            //                          Console.WriteLine(items.city);
            //                      }
            //   

            //12.List Unique capital
            //  List<string> DemoNew = users.Select(x => x.capital).Distinct().ToList();
            //     foreach (var user in DemoNew)
            // {
            //     Console.WriteLine(user);
            // }

            //13.upper case / lowercase

            // List<string> demo = users.Select(x => x.city).ToList();

            // foreach (var item in demo)
            // {
            //     Console.WriteLine(item.ToUpper());
            // }

            // List<string> demos = users.Select(x => x.city).ToList();

            // foreach (var item in demo)
            // {
            //     Console.WriteLine(item.ToLower());
            // }

            //14.String to double/float

            // IEnumerable<string>  pop = users.Select(x => x.population);
            //      double result;
            // foreach (var item in pop)
            // {
            //     try{
            // result =Double.Parse(item);
            // Console.WriteLine(result);
            //     }
            //      catch (FormatException) {
            //     Console.WriteLine("0",
            //     item.GetType().Name, item);

            // 15. Show only 3 values for lat/ lng
            // IEnumerable<string> demo = users.Select(x => x.lat).Take(3);

            // foreach (var item in demo)
            // {

            //     Console.WriteLine(item);
            // }

            //16.Print country name in A-Z
            // List<Demo> demo = users.OrderBy(x => x.country).ToList();
            // for(int i=0;i<demo.Count();i++)
            // {
            //     Console.WriteLine(demo[i].country);
            // }

            //17.duplicate cities

            // List<string> demo = users.GroupBy(x => x.city).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

            //    foreach (var item in demo)
            //    {
            //     Console.WriteLine(item);
            //    }

            //18.print the cities ending with "ing"

            // List<Demo> demo = users.OrderBy(x => x.city.EndsWith("ing")).ToList();
            // foreach (var item in demo)
            // {
            //     Console.WriteLine(item.city);
            // }

            //19.Remove the space from City "New York" as NewYork
            //        string NewDemo=users.Select(x=>x.city.StartsWith("New")).ToString();

            //    for (int i=0;i<NewDemo.Count();i++)
            //    {
            //         Console.WriteLine(NewDemo.Split(' ').ToList());
            //    }

            //}

        }



}



