using Lab_2.Models;
using Lab_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Lab_2
{
    public class FontFactory
    {
        public static IEnumerable<FontViewModel> GetNewFonts()
        {
            List<FontViewModel> fonts = new List<FontViewModel>();

            foreach (var fontFamily in Fonts.SystemFontFamilies)
            {
                Font font = new Font();
                font.FontFamily = fontFamily;
                font.Size = 12;
                font.IsFavorite = false;
                List<Culture> cultures = new List<Culture>();
                foreach (var family in fontFamily.FamilyNames)
                {
                    cultures.Add(new Culture { CultureType = family.Key.ToString(), Name = family.Value });
                }
                font.Cultures = cultures;
                font.Comment = "";
                FontViewModel fontViewModel = new FontViewModel(font);
                fonts.Add(fontViewModel);
            }

            return fonts;
        }

        internal static IEnumerable<FontViewModel> GetFontsFromFile()
        {
            List<FontViewModel> fonts = new List<FontViewModel>();
            IEnumerable<SavedFont> savedFonts = Json.DeserializeFontsFromFile($"{AppDomain.CurrentDomain.BaseDirectory}settings.json");

            foreach (var fontFamily in Fonts.SystemFontFamilies)
            {
                Font font = new Font();
                font.FontFamily = fontFamily;
                font.Size = 12;
                font.IsFavorite = false;
                List<Culture> cultures = new List<Culture>();

                foreach (var family in fontFamily.FamilyNames)
                {
                    cultures.Add(new Culture { CultureType = family.Key.ToString(), Name = family.Value });
                }

                font.Cultures = cultures;
                font.Comment = "";

                var savedFont = savedFonts.Where(f => f.FontFamily.Equals(font.FontFamily.ToString())).FirstOrDefault();

                //save some time if no fonts were loaded from save file
                if (savedFonts.Any())
                {
                    if (savedFont != null)
                    {
                        font.IsFavorite = savedFont.IsFavorite;
                        font.Comment = savedFont.Comment;
                    }
                }

                FontViewModel fontViewModel = new FontViewModel(font);
                fonts.Add(fontViewModel);
            }
            return fonts;
        }
    }
}
