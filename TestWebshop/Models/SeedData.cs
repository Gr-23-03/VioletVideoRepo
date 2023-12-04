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
                     ImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthedailyguardian.com%2Fmission-impossible-dead-reckoning-part-one%2F&psig=AOvVaw27TCwGYi98csvR-I9ttZ2m&ust=1701096883765000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCICusu714YIDFQAAAAAdAAAAABAE"
                 },
                    new Movie()
                    {
                        Id = 2,
                        Title = "Heart of Stone",
                        Director = "Tom Harper",
                        ReleaseYear = 2023,
                        Price = 299,
                        Genre = "Action",
                        ImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt13603966%2F&psig=AOvVaw0XQE71_lOUgZELqCt4Xsd6&ust=1701096791642000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCLD0xsL14YIDFQAAAAAdAAAAABAE"


                    },

                    new Movie()
                    {
                        Id = 3,
                        Title = "When Harry Met Sally",
                        Director = "Rob Reiner",
                        ReleaseYear = 1989,
                        Price = 77,
                        Genre = "Romantic Comedy",
                        ImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0098635%2F&psig=AOvVaw3Au9W4p6cLjjvgaDHpHjAN&ust=1701107299984000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCLDXhdWc4oIDFQAAAAAdAAAAABAE"
                    },

                    new Movie()
                    {

                        Id = 4,
                        Title = "Ghostbusters ",
                        Director = "Ivan Reitman",
                        ReleaseYear = 1984,
                        Price = 177,
                        Genre = "Comedy",
                        ImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0087332%2F&psig=AOvVaw2rGeYGMa_IcNckkUqqUKqN&ust=1701107357993000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCID-0_Cc4oIDFQAAAAAdAAAAABAK"
                    


                    });



            modelBuilder.Entity<OrderRow>().HasData(

                new OrderRow()
                {
                   Id=1,
                   OrderId=1,
                   MovieId=1,
                   Price=129,

                 });


        }

}

    


}





