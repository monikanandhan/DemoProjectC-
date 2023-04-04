﻿namespace MyBooksDemo.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }  
       public string Genere { get; set; }
        
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
            
        
                    
    }
}
