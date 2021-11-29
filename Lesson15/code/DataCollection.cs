using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson15
{
    public class DataCollection<T> : IEnumerable<T>
    {
        private List<T> _items;

        public DataCollection()
        {
            _items = new List<T>();
        }

        public void Add(T item) 
        {
            _items.Add(item);
        }

        public T GetElementByIndex(int index)
        {
            return _items[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();    
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
    }
}
