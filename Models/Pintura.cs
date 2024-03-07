using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenWPFApp.Models
{
    public class Pintura
    {
        private int id;
        private string title;
        private int year;
        private string file;
        private int genre_id;
        private int artist_id;
        private ArtistClass artist;
        private GenreClass genre;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int Year { get => year; set => year = value; }
        public string File { get => file; set => file = value; }
        public int GenreId { get => genre_id; set => genre_id = value; }
        public int ArtistId { get => artist_id; set => artist_id = value; }
        public GenreClass Genre { get => genre; set => genre = value; }
        public ArtistClass Artist { get => artist; set => artist = value; }


        public class GenreClass
        {
            private string name;

            public string Name { get => name; set => name = value; }
        }

        public class ArtistClass
        {
            private string name;

            public string Name { get => name; set => name = value; }
        }

    }
}
