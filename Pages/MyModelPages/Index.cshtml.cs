using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using MigrationsExample.Models;

namespace MigrationsExample.Pages_MyModelPages
{
    public class IndexModel : PageModel
    {
        private readonly MigrationsExample.Models.MyBlogContext _context;

        public IndexModel(MigrationsExample.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;
        public int countPages {get;set;}
        public int itemPage =10;
        [BindProperty(SupportsGet =true,Name ="p")]
        public int currentPage {get;set;}

        public async Task OnGetAsync( string Search)
        {
            var total = await _context.article.CountAsync();
             countPages =  (int)(total / (itemPage));
             if (currentPage <1)
             currentPage=1;
             if(currentPage>countPages)
             currentPage=countPages;



       
            var linq = await (from a in _context.article
            orderby a.PublishDate descending
            select a).ToListAsync();
            
            if(Search!=null)
            {
                var linq2 = await (from a in _context.article
                    where a.Title.Contains(Search)
                    select a).ToListAsync();
                    Article = linq2;
                    ///tim theo trong bang
                    linq.Where(a=> a.Title.Contains(Search));
                   // linq2.Where(a => a.Title.Contains(Search)).ToList();
            }
            else
            {
                Article =  linq;
            }
                //Article =;
                //await _context.article.ToListAsync()
                
            
        }
    }
}
