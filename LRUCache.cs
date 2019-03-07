using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
   
    public class Cache
    {
        public class LinkedListNode
        {
            public LinkedListNode next, prev;
            public int Key;
            public String Value;

            public LinkedListNode(int k, String v)
            {
                Key = k;
                Value = v;
            }

            public LinkedListNode()
            {

            }

            public override string ToString()
            {
                return $"key:{Key}, value:{Value}";
            }

            public String PrintForward()
            {
                String data = "(" + Key + "," + Value + ")";
                if (next != null)
                {
                    return data + "->" + next.PrintForward();
                }
                else
                {
                    return data;
                }
            }


        }

        private int maxCacheSize;
        private Dictionary<int, LinkedListNode>  map = new Dictionary<int, LinkedListNode>();
        private LinkedListNode head = null;
        private LinkedListNode tail = null; 

        public Cache(int size)
        {
            maxCacheSize = size;
        }

        public String GetValue(int key)
        {
            LinkedListNode item = map.ContainsKey(key) ? map.GetValueOrDefault(key) : null;
            if (item == null)
                return null;

            if(item != head)
            {
                //move to front
                RemoveFromList(item);
                InsertInFront(item);
            }

            return item.Value;
        }

        public void RemoveFromList(LinkedListNode node)
        {
            if(node == null)
            {
                return;
            }

            if(node.prev != null)
            {
                node.prev.next = node.next;
            }
            if(node.next != null)
            {
                node.next.prev = node.prev;
            }

            if(node == tail)
            {
                tail = node.prev;
            }
            if(node == head)
            {
                head = node.next;
            }
        }

        public void InsertInFront(LinkedListNode node)
        {
            if(head == null)
            {
                head = node;
                tail = node;
            } else
            {
                head.prev = node;
                node.next = head;
                head = node;
            }
        }

        public Boolean RemoveKey(int key)
        {
            LinkedListNode node = map.GetValueOrDefault(key, null);
            if (node == null)
                return true;
            RemoveFromList(node);
            map.Remove(key);
            return true;
        }

        public void SetKeyValue(int key, String value)
        {
            RemoveKey(key);

            if(map.Count >= maxCacheSize && tail != null)
            {
                RemoveKey(tail.Key);
            }

            var node = new LinkedListNode(key, value);
            InsertInFront(node);
            map.Add(key, node);
        }

        public String GetCacheAsString()
        {
            if (head == null) return "";
            return head.PrintForward();
        }




    }
    public class LRUCache
    {

        public void RunMe() {

            int cache_size = 5;
            Cache cache = new Cache(cache_size);

            cache.SetKeyValue(1, "1");
            Console.WriteLine(cache.GetCacheAsString());
            
            cache.SetKeyValue(2, "2");
            Console.WriteLine(cache.GetCacheAsString());
            cache.SetKeyValue(3, "3");
            Console.WriteLine(cache.GetCacheAsString());
            cache.GetValue(1);
            Console.WriteLine(cache.GetCacheAsString());
            cache.SetKeyValue(4, "4");
            Console.WriteLine(cache.GetCacheAsString());
            cache.GetValue(2);
            Console.WriteLine(cache.GetCacheAsString());
            cache.SetKeyValue(5, "5");
            Console.WriteLine(cache.GetCacheAsString());
            cache.GetValue(5);
            Console.WriteLine(cache.GetCacheAsString());
            cache.SetKeyValue(6, "6");
            Console.WriteLine(cache.GetCacheAsString());
            cache.GetValue(1);
            Console.WriteLine(cache.GetCacheAsString());
            cache.SetKeyValue(5, "5a");
            Console.WriteLine(cache.GetCacheAsString());
            cache.GetValue(3);
            Console.WriteLine(cache.GetCacheAsString());
        }

        
    }
}
