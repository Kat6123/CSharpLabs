using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class ActorCollection : MyCollection<Actor>
    {
        public ActorCollection() : base() { }
        public ActorCollection(List<Actor> actors) : base() { items = actors; }

        public void SortByName()
        {
            items.Sort((x, y) =>
            {
                if (x.Name == null && y.Name == null) return 0;
                if (x.Name == null) return -1;
                if (y.Name == null) return 1;
                return x.Name.CompareTo(y.Name);
            });
        }

        public ActorCollection FindAllByFilmTitle(string Title)
        {
            return new ActorCollection(
                items.FindAll(x =>
                {
                    foreach (var film in x.Films)
                    {
                        if (film.Title.Equals(Title))
                            return true;
                    }
                    return false;
                }
                )
            );
        }

    }
}
