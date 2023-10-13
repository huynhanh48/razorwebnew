using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MigrationsExample.Models;

namespace MigrationsExample.Pages_MyModelPages
{
    public class CreatedArticleModel : PageModel
    {
        private  readonly MigrationsExample.Models.MyBlogContext _myBlogContext;
        public CreatedArticleModel(MigrationsExample.Models.MyBlogContext myBlogContext)
        {
            _myBlogContext = myBlogContext;
        }
        [BindProperty(SupportsGet =true)]
        public IList<Article> GetArticles{get;set;}=default;
        [BindProperty]
        public Article article {get;set;}
        public void OnGet( string? Search)
        {
            if(Search != null)
            {
                var linq = (from a in _myBlogContext.article
                where a.Content.Contains(Search)
                select a).ToList();
                GetArticles = linq;
            }else
            {
                var linq2 = (from a in _myBlogContext.article
                select a).ToList();
                GetArticles = linq2;
            }
        }
    }
}
