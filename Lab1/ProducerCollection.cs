using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class ProducerCollection : MyCollection<Producer>
    {
        public ProducerCollection() : base() { }
        public ProducerCollection(List<Producer> producers) : base() { items = producers; }

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

        public ProducerCollection FindAllByFilmTitle(string Title)
        {
            return new ProducerCollection(
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
