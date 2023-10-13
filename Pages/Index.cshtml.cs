using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MigrationsExample.Models;
using MigrationsExample.Models;

namespace MigrationsExample.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext myBlogContext;

    public IndexModel(ILogger<IndexModel> logger , MyBlogContext _myBlogContext)
    {
        _logger = logger;
        myBlogContext = _myBlogContext;
    }

    public void OnGet()
    {
        var post = (from a in myBlogContext.article
        orderby a.PublishDate descending 
        select a).ToList();
        ViewData["post"]=post;
    }
}
