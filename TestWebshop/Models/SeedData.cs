using Microsoft.EntityFrameworkCore;
using TestWebshop.Data;
using TestWebshop.Models.Database;
using Microsoft.AspNetCore.Builder;

namespace TestWebshop.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Movie>().HasData(
               
                 new Movie()
                 {
                     Id = 1,
                     Title = "Mission Impossible",
                     Director = " Christopher McQuarrie",
                     ReleaseYear = 2023,
                     Price = 179 - 50,
                     Genre = "Action",
                     ImageURL = "https://media.ginza.se/Images/item_img_150/15084.jpg"
                 },
                    new Movie()
                    {
                        Id = 2,
                        Title = "Heart of Stone",
                        Director = "Tom Harper",
                        ReleaseYear = 2023,
                        Price = 299,
                        Genre = "Action",
                        ImageURL = "https://media.ginza.se/Images/item_img_150/138194.jpg"


                    },

                    new Movie()
                    {
                        Id = 3,
                        Title = "When Harry Met Sally",
                        Director = "Rob Reiner",
                        ReleaseYear = 1989,
                        Price = 77,
                        Genre = "Romantic Comedy",
                        ImageURL = "https://media.ginza.se/Images/item_img_150/13909.jpg"

                    },
                    new Movie()
                    {

                        Id = 4,
                        Title = "Ghostbusters ",
                        Director = "Ivan Reitman",
                        ReleaseYear = 1984,
                        Price = 177,
                        Genre = "Comedy",
                        ImageURL = "https://media.ginza.se/Images/item_img_150/409994.jpg"



                    });



         


        }

}

    


}





