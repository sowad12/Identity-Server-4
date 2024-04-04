using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Library.Model.ViewModel
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string Owner { get; set; }
    }
}
