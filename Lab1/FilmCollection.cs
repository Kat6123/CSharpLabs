using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class FilmCollection : MyCollection<Film>
    {
        public FilmCollection() : base() { }
        public FilmCollection(List<Film> films) : base() {
            items = films;
        }

        public void SortByTitle()
        {
            items.Sort((x, y) =>
            {
                if (x.Title == null && y.Title == null) return 0;
                if (x.Title == null) return -1;
                if (y.Title == null) return 1;
                return x.Title.CompareTo(y.Title);
            });
        }
        public void SortByYear()
        {
            items.Sort((x, y) => x.Year.CompareTo(y.Year));
        }
        public void SortByAgeLimit()
        {
            items.Sort((x, y) => x.AgeLimit.CompareTo(y.AgeLimit));
        }

        public FilmCollection FindAllByGenre(string Genre)
        {
            return new FilmCollection(
                items.FindAll(x =>
                {
                    foreach (var gen in x.Genres)
                    {
                        if (gen.Equals(Genre))
                            return true;
                    }
                    return false;
                }
                )
            );
        }
        public FilmCollection FindAllByActorName(string Name)
        {
            return new FilmCollection(
                items.FindAll(x =>
                    {
                        foreach (var act in x.Actors)
                        {
                            if (act.Name.Equals(Name))
                                return true;
                        }
                        return false;
                    }
                )
            );
        }
        public FilmCollection FindAllByYear(uint Year)
        {
            return new FilmCollection(items.FindAll(x => x.Year.Equals(Year)));
        }
        public FilmCollection FindAllByAgeLimit(uint AgeLimit)
        {
            return new FilmCollection(items.FindAll(x => x.AgeLimit.Equals(AgeLimit)));
        }
        public FilmCollection FindAllByProducerName(string Name)
        {
            return new FilmCollection(items.FindAll(x => x.Producer.Name.Equals(Name)));
        }
        public Film FindByTitle(string Title) => items.Find(x => x.Title.Equals(Title));
    }
}
