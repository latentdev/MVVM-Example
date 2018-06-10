using Lab_2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lab_2.ViewModels
{
    public class FontViewModel : ViewModelBase
    {
        private Visibility isVisible;

        public FontViewModel(Font model)
        {
            Model = model;
        }

        [JsonIgnore]
        public Font Model { get; private set; }

        public FontFamily FontFamily
        {
            get
            {
                return Model.FontFamily;
            }
            set
            {
                Model.FontFamily = value;
                OnPropertyChanged(nameof(Model.FontFamily));
            }
        }

        public String Comment
        {
            get
            {
                return Model.Comment;
            }
            set
            {
                Model.Comment = value;
                OnPropertyChanged(nameof(Model.Comment));
            }
        }

        [JsonIgnore]
        public int Size
        {
            get
            {
                return Model.Size;
            }
            set
            {
                Model.Size = value;
                OnPropertyChanged(nameof(Model.Size));
            }
        }

        public bool IsFavorite
        {
            get
            {
                return Model.IsFavorite;
            }
            set
            {
                Model.IsFavorite = value;
                OnPropertyChanged(nameof(Model.IsFavorite));
            }
        }

        [JsonIgnore]
        public Visibility IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        [JsonIgnore]
        public List<Culture> Cultures

        {
            get => Model.Cultures;
        }
    }
}
