using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_2.Models
{
    public class Font
    {
        public FontFamily FontFamily { get; set; }
        public String Comment { get; set; }
        public int Size { get; set; }
        public bool IsFavorite { get; set; }
        public List<Culture> Cultures { get; set; }
    }
}
