using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MigrationsExample.Models;

namespace MigrationsExample.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    MyBlogContext myBlogContext;

    public PrivacyModel(ILogger<PrivacyModel> logger,MyBlogContext _myblogcontext)
    {
        _logger = logger;
        myBlogContext=_myblogcontext;
    }

    public void OnGet()
    {
        var post = (from ouput in myBlogContext.article
        orderby ouput.PublishDate descending
        select ouput).ToList();
        ViewData["post"] = post;
    }
}

