using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Day15_BST_UC1
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        //intialize 
        public T NodeData { get; set; }
        public BinarySearchTree<T> leftTree { get; set; }
        public BinarySearchTree<T> rightTree { get; set; }
        //constructor
        public BinarySearchTree(T nodeData)
        {
            this.NodeData = nodeData;
            this.rightTree = null;
            this.leftTree = null;

        }
        //intialize variables
        int leftCount; int rightCount;
        
        //define insert method
        public void Insert(T item)
        {
            T currentNodeValue = this.NodeData;
            if ((currentNodeValue.CompareTo(item)) > 0)
            {
                if (this.leftTree == null)
                {
                    this.leftTree = new BinarySearchTree<T>(item);
                }
                else
                    this.leftTree.Insert(item);
                this.leftCount++;
            }
            else
            {
                if (this.rightTree == null)
                {
                    this.rightTree = new BinarySearchTree<T>(item);
                }
                else
                    this.rightTree.Insert(item);
                this.rightCount++;
            }
        }


        public void Display()
        {
            if (this.leftTree != null)
            {
                
                this.leftTree.Display();
            }
            Console.WriteLine(this.NodeData);
            if (this.rightTree != null)
            {
                
                this.rightTree.Display();
            }
        }

        public void GetSize()
        {
            Console.WriteLine("Size" + " " + (1 + this.leftCount + this.rightCount));
        }

        
    }
 class Program
    {
        public static void Main()
        {
            BinarySearchTree<int> binarySearch = new BinarySearchTree<int>(56);
            binarySearch.Insert(30);
            binarySearch.Insert(70);
            binarySearch.GetSize();
            binarySearch.Display();
        }
    }
        
    
}