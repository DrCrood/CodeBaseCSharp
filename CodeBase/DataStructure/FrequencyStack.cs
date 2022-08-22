using System.Collections.Generic;

namespace CodeBase.DataStructure
{
    /// <summary>
    /// A stack that pop the most frequent item 
    /// </summary>
    public class FrequencyStatck
    {
        private readonly Dictionary<int, int> NumFreMap;
        private readonly MaxHeap maxFreHeap;
        private readonly LinkedList<int> numbers;

        public FrequencyStatck()
        {
            NumFreMap = new Dictionary<int, int>();
            maxFreHeap = new MaxHeap(20);
            numbers = new LinkedList<int>();
        }

        public void Push(int n)
        {
            if (NumFreMap.ContainsKey(n))
            {
                NumFreMap[n]++;
            }
            else
            {
                NumFreMap.Add(n, 1);
            }
            maxFreHeap.Push(NumFreMap[n]);
            numbers.AddFirst(n);
        }

        public int Pop()
        {
            LinkedListNode<int> node = numbers.First;
            int maxFre = maxFreHeap.Pop();
            while (NumFreMap[node.Value] != maxFre)
            {
                node = node.Next;
            }
            NumFreMap[node.Value]--;
            numbers.Remove(node);
            return node.Value;
        }

    }
}
