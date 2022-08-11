using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.DataStructure
{
    /// <summary>
    /// Least frequent used cache
    /// </summary>
    public class LFUCache
    {
        private readonly int capacity;
        LinkedList<Node> cache;
        Dictionary<int,Node> visited;
        int size = 0;
        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new LinkedList<Node>();
            visited = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if(visited.TryGetValue(key, out Node node))
            {
                cache.Remove(node);
                cache.AddFirst(node);
                return node.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if(visited.ContainsKey(key))
            {
                Node node = (Node)visited[key];
                cache.Remove(node);
                Node newNode = new Node() { Key = key, Value = value };
                cache.AddFirst(newNode);
                visited[key] = newNode;
            }
            else
            {
                if (size == capacity)
                {
                    Node node = cache.Last.Value;
                    visited.Remove(node.Key);
                    node.Key = key;
                    node.Value = value;
                    cache.RemoveLast();
                    cache.AddFirst(node);
                    visited.Add(key, node);
                    return;
                }
                Node newNode = new Node() { Key = key, Value = value };
                cache.AddFirst(newNode);
                visited.Add(key, newNode);
                size++;
            }
        }
    }

    public class Session
    {
        public int Key;
        public int Value;
    }
}
