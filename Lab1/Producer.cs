using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class Producer : IEquatable<Producer>
    {
        public string Name { get; set; }
        public FilmCollection Films { get; set; }

        public Producer()
        {
            Films = new FilmCollection();
        }
        public Producer(string name)
        {
            Films = new FilmCollection();
            this.Name = name;
        }

        public void AddFilm(uint AgeLimit, string Title, uint Year)
        {
            var film = new Film(AgeLimit, Title, Year);
            Films.Add(film);
            film.Producer = this;
        }

        public bool Equals(Producer prod)
        {
            if (prod == null)
                return false;
            if (Name == prod.Name)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Producer prod = obj as Producer;
            if (prod == null)
                return false;
            else
                return Equals(prod);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
