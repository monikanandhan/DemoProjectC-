using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Model
{
    public class BookDBInitalizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookDbContext>();
                if(!context.bookDemo.Any())
                {
                    context.bookDemo.AddRange(new Book()
                    {
                        Title = "First Book",
                        Description = " Fisrt Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genere = "Fiction",
                        Author = "monica",
                        CoverUrl = "https.....",
                        DateAdded = DateTime.Now

                    }, new Book()
                    {
                        Title = "Second Book",
                        Description = " Second Book Description",
                        IsRead = false,
                        DateRead = DateTime.Now.AddDays(-8),
                        Rate = 3,
                        Genere = "Biography",
                        Author = "sandhiya",
                        CoverUrl = "https.....",
                        DateAdded = DateTime.Now

                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
