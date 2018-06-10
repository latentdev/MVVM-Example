using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.ViewModels
{
    public class FontListViewModel : ViewModelBase
    {
        public FontListViewModel(IEnumerable<FontViewModel> model)
        {
            Model = model;
        }

        private IEnumerable<FontViewModel> model;
        public IEnumerable<FontViewModel> Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

    }
}
