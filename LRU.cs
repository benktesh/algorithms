using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{

    public class LRU
    {
        public class Cache
        {
            private int _size;
            HashSet<int> map;
            private LinkedList<int> queue;

            public Cache(int size)
            {
                _size = size;
                map = new HashSet<int>();
                queue = new LinkedList<int>();
            }

            public void Get(int data)
            {
                if (!map.Contains(data))
                {
                    if (queue.Count == _size)
                    {
                        var last = queue.Last;
                        queue.RemoveLast();
                        map.Remove(last.Value);
                    }
                }
                else
                {
                    var it = queue.GetEnumerator();
                    int index = 0;
                    int i = 0;
                    while (it.MoveNext())
                    {
                        if (it.Current == data)
                        {
                            index = i;
                            break;
                        }

                        i++;
                    }
                    queue.Remove(index);
                }
                queue.AddFirst(data);
                map.Add(data);
            }

            public void Display()
            {
                Console.Write($"\nDisplaying Current Cache \n");
                var it = queue.GetEnumerator();
                while (it.MoveNext())
                {
                    Console.Write($"{it.Current} ");
                }
            }
        }

        public void RunMe()
        {
            int cache_size = 4;
            Cache cache = new Cache(cache_size);

            cache.Get(1);
            cache.Get(2);
            cache.Get(3);
            cache.Get(1);
            cache.Get(4);
            cache.Get(5);
            cache.Display();
        }
    }
}
