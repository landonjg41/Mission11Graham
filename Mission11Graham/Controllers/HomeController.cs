using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission11Graham.Models;
using System.Linq;


namespace Mission11Graham.Controllers;

public class HomeController : Controller
{
    private IBookInterface _repo;
    public int PageSize = 10;

    public HomeController(IBookInterface repo)
    {
        _repo = repo;
    }
   
    public IActionResult Index(int pageNum = 1)
    {
        var booksQuery = _repo.Books
            .OrderBy(b => b.BookId)
            .Skip((pageNum - 1) * PageSize)
            .Take(PageSize);

        var totalBooks = _repo.Books.Count();

        var paginationInfo = new
        {
            CurrentPage = pageNum,
            TotalPages = (int)Math.Ceiling((decimal)totalBooks / PageSize)
        };

        ViewBag.PaginationInfo = paginationInfo;

        return View(booksQuery.ToList());
    }
}

