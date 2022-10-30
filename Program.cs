using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable_uc2
{
    class MyMapNode<K, V>
    {
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }



        public int GetFrequencyOfWords(V Value)
        {
            int count = 0;
            if (items == null)
            {
                Console.WriteLine("Hash Table is Empty!");
                return 0;
            }
            for (int i = 0; i < items.Length; i++)
            {
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(i);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Value.Equals(Value))
                        count++;
                }
            }
            return count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<int, string> hash = new MyMapNode<int, string>(10);
            hash.Add(0, "Paranoid");
            hash.Add(1, "Are");
            hash.Add(2, "Not");
            hash.Add(3, "Paranoid");
            hash.Add(4, "Because");
            hash.Add(5, "They");
            hash.Add(6, "Are");
            hash.Add(7, "Paranoid");
            hash.Add(8, "But");
            hash.Add(9, "Because");
            hash.Add(10, "They");

            Console.WriteLine(hash.GetFrequencyOfWords("Paranoid"));
        }
    }
}
