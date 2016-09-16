using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class Actor : IEquatable<Actor>
    {
        public string Biography { get; set; }
        public string Birth { get; set; }
        public string Name { get; set; }
        public FilmCollection Films { get; set; }

        public Actor()
        {
            Films = new FilmCollection();
        }
        public Actor(string Biography, string Birth, string Name)
        {
            Films = new FilmCollection();
            this.Biography = Biography;
            this.Birth = Birth;
            this.Name = Name;
        }

        public void AddFilm(uint AgeLimit, string Title, uint Year)
        {
            var film = new Film(AgeLimit, Title, Year);
            Films.Add(film);
            film.Actors.Add(this);
        }

        public bool Equals(Actor act)
        {
            if (act == null)
                return false;
            if (Name == act.Name && Birth == act.Birth)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Actor act = obj as Actor;
            if (act == null)
                return false;
            else
                return Equals(act);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
