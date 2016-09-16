using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class Film : IEquatable<Film>
    {
        public ActorCollection Actors { get; set; }                 
        public uint AgeLimit { get; set; }
        public MyCollection<string> Genres { get; set; }
        public Producer Producer { get;  set; }
        public string Title { get; set; }
        public uint Year { get; set; }

        public Film()
        {
            Actors = new ActorCollection();
            Genres = new MyCollection<string>();
            Producer = new Producer();
        }
        public Film(uint AgeLimit, string Title, uint Year)
        {
            Actors = new ActorCollection();
            Genres = new MyCollection<string>();
            Producer = new Producer();
            this.AgeLimit = AgeLimit;
            this.Title = Title;
            this.Year = Year;
        }

        public void AddActor(string biography, string birth, string name)
        {
            var act = new Actor(biography, birth, name);
            Actors.Add(act);
            act.Films.Add(this);
        }
        public void AddGenre(string genre) => Genres.Add(genre);
        public void AddProducer(string name)
        {
            var prod = new Producer(name);
            Producer = prod;
            prod.Films.Add(this);
        }

        public bool Equals(Film film)
        {
            if (film == null)
                return false;
            if (this.Year == film.Year && this.Title == film.Title)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Film film = obj as Film;
            if (film == null)
                return false;
            else
                return Equals(film);
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}

