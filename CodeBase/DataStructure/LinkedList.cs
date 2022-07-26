using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.DataStructure
{
    public class LinkedListDemo
    {
        public int LinkedListSum()
        {
            int[] a = new int[10];
            for (int i = 0; i < 10; i++)
            {
                a[i] = i;
            }
            LinkedList<int> ll = new LinkedList<int>(a);

            LinkedListNode<int> current = ll.First;
            int sum = 0;
            while (current is not null)
            {
                sum += current.Value;
                current = current.Next;
            }

            IList<int> list = new List<int>();

            IList<IList<int>> list2 = new List<IList<int>>();

            return sum;
        }
    }
}
