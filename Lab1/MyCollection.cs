using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_1
{
    public class MyCollection<T> : ICollection<T>
    {
        protected List<T> items;
        private int _change;

        public int Count =>items.Count;
        public bool IsReadOnly => false; 

        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public MyCollection()
        {
            items = new List<T>();
        }

        public void Add(T item)   
        {
            if (!(items.Contains(item)))
            {
                items.Add(item);
                _change++;
            }
            else
            {
                Console.WriteLine("This element was already added!");
            }
        }
        public bool Contains(T item) 
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(item))
                    return true;
            }
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                Console.WriteLine("The array cannot be null.");
                return;
            }
            if (arrayIndex < 0)
            {
                Console.WriteLine("The starting array index cannot be negative.");
                return;
            }
            if (Count > array.Length - arrayIndex)
            {
                Console.WriteLine("The destination array has fewer elements than the collection.");
                return;
            }
            items.CopyTo(array, arrayIndex);
        }
        public void Clear() => items.Clear();
        public bool Remove(T item) => items.Remove(item);

        IEnumerator IEnumerable.GetEnumerator()
        {
            var change = _change;
            for(var i = 0; i < items.Count; i++)
            {
                if (change != _change)
                    throw new Exception();
                else
                    yield return items[i];
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            var change = _change;
            for (var i = 0; i < items.Count; i++)
            {
                if (change != _change)
                    throw new Exception();
                else
                    yield return items[i];
            }
        }
    }
} 
