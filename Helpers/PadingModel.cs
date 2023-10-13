using System;
namespace HA.TagHelpers
{
    public class PadingModel
    {
        public int currentPages {get;set;}
        public int countPages {get;set;}
        public Func<int?,string> GeneraterUrl {get;set;}
    }
}