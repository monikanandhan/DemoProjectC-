using ClassRegistration;
using ClassRegistration.Controllers;
using ClassRegistration.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    public abstract class TestRegistration
    {
      
        public DbContextOptions<RegisterDbContext> ContextOptions { get; set; }
        public TestRegistration(DbContextOptions<RegisterDbContext> options) 
        {
            ContextOptions = options;
           
            Seed();
        }

        private void Seed()
        {

            using (var context = new RegisterDbContext(ContextOptions))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new Register()
                {
                    Name = "Test One",
                    Age = 40
                };

                var two = new Register()
                {
                    Name = "Test Two",
                    Age = 50
                };

                var three = new Register()
                {
                    Name = "Test Three",
                    Age = 60
                };
                context.AddRange(one, two, three);
                context.SaveChanges();
            }
        }
        [Fact]
        public void TestGetRegister()
        {
                using (var context = new RegisterDbContext(ContextOptions))
                {
                    // Arrange
                    var controller = new RegisterController(context);
                var result = controller.GetRegistrationDetails() as OkObjectResult;
                //Assert.IsType<OkObjectResult>(result as OkObjectResult);
               var number= Assert.IsType<List<Register>>(result.Value);
                Assert.Equal(3, number.Count);

            }
        }

        [Fact]
        public void TestGetRegisterById()
        {
            using (var context = new RegisterDbContext(ContextOptions))
            {
                int id = 2;
                var controller = new RegisterController(context);
                var result = controller.GetRegistrationById(id) as OkObjectResult;

                var response = result.Value as Register;

                Assert.IsType<Register>(result.Value);
                Assert.Equal(id, response.Id);
            }
        }

        [Fact]
        public void AddNewRegister()
        {
            using (var context = new RegisterDbContext(ContextOptions))
            {
                // Arrange
                var controller = new RegisterController(context);
                Register reg = new Register()
                {

                    Name = "kalai",
                    Age = 45
                };
                var result = controller.AddRegistrationDetails(reg) as OkObjectResult;

                var item = result.Value as Register;
                Assert.IsType<Register>(item);
                Assert.Equal(45, item.Age);
            }
        }

        [Fact]
        public void DeleteByID()
        {
            using (var context = new RegisterDbContext(ContextOptions))
            {

                var controller = new RegisterController(context);
                int pid = 2;
                var result = controller.DeleteById(pid);
                Assert.IsType<OkObjectResult>(result);
            }


            using (var contexts = new RegisterDbContext(ContextOptions))
            {
                var controllers = new RegisterController(contexts);
                var results = controllers.GetRegistrationDetails() as OkObjectResult;

                var number = Assert.IsType<List<Register>>(results.Value);

                Assert.Equal(2, number.Count);
            }

        }
    }
}
