
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TestWebshop.Models
{
    public class Pager
    {
       
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        
        public Pager()
        {
        }

        public Pager(int totalMovies, int page, int pageSize = 4)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalMovies / (decimal)pageSize);
            int currentPage = page;

            const int maxPagesToShow = 5;

            int startPage = 1;
            int endPage = totalPages;

            if (totalPages > maxPagesToShow)
            {
                int middle = maxPagesToShow / 2;
                startPage = currentPage - middle;
                endPage = currentPage + middle - 1;

                if (startPage < 1)
                {
                    startPage = 1;
                    endPage = maxPagesToShow;
                }
                else if (endPage > totalPages)
                {
                    endPage = totalPages;
                    startPage = totalPages - maxPagesToShow + 1;
                }
            }

            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            TotalItems = totalMovies;
           
        }


    }



}
