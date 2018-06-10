using Lab_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_2
{
    public static class Extensions
    {
        public static IEnumerable<FontViewModel> Filter(this IEnumerable<FontViewModel> fonts, String searchTerm, bool filterFavorite, bool filterComment)
        {

            IEnumerable<FontViewModel> results = fonts;
            IEnumerable<FontViewModel> fontsMatchingSearch = fonts.Where(font => font.FontFamily.ToString().ToLower().Contains(searchTerm.ToLower()));
            IEnumerable<FontViewModel> fontsFavorite = fonts.Where(font => font.IsFavorite == true);
            IEnumerable<FontViewModel> fontsWithComment = fonts.Where(font => !font.Comment.Equals(""));

            if(!searchTerm.Equals(""))
            {
                results = results.Intersect(fontsMatchingSearch);
            }
            if(filterFavorite)
            {
                results = results.Intersect(fontsFavorite);
            }
            if(filterComment)
            {
                results = results.Intersect(fontsWithComment);
            }
            
            return results.ToList();
        }

        public static IEnumerable<FontViewModel> Filter(this IEnumerable<FontViewModel> fonts)
        {
            return fonts.Where(font => font.IsFavorite == true || !font.Comment.Equals(""));
        }


    }
}
