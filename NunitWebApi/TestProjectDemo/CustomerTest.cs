using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MySqlX.XDevAPI.Common;
using NunitWebApi;
using NunitWebApi.Controllers;
using NunitWebApi.Model;
using NunitWebApi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDemo
{
    public abstract class CustomerTest
    {
        public DbContextOptions<CustomerDbContext> options { get; set; }
        public CustomerTest(DbContextOptions<CustomerDbContext> _options)
        {
            options = _options;
        
        }

        private void Seed()
        {

            using (var context = new CustomerDbContext(options))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new Customer()
                {
                    Name = "Test One",
                    Age = 40,
                    phone="9080592602"
                };

                var two = new Customer()
                {
                    Name = "Test Two",
                    Age = 50,
                    phone="9940700590"
                };

                var three = new Customer()
                {
                    Name = "Test Three",
                    Age = 60,
                    phone= "9566348325"
                };
                context.AddRange(one, two, three);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetCustomer()
        {

            using (var context=new CustomerDbContext(options))
            {
                var service = new CustomerService(context);
                
                    var controller = new CustomerController(service);
                    var response = controller.GetCustomer() as OkObjectResult;
               
                Assert.AreEqual(2, (response.Value));
                
            } 

        }
    }
}
