using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask4_2
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }

    public interface ITree
    {
        void AddItem(int value); // добавить узел
        TreeNode GetNodeByValueBFS(int value); //получить узел дерева по значению BFS
        TreeNode GetNodeByValueDFS(int value); //получить узел дерева по значению DFS
        void PrintTree(TreeNode root, string space); //вывести дерево в консоль
    }

    public class BinaryTree : ITree
    {
        public static TreeNode head;

        public void AddItem(int value)
        {
            TreeNode tmp = null;
            if (head == null)
            {
                head = new TreeNode() { Value = value };
                return;
            }
            tmp = head;
            while (tmp != null)
                if (tmp.Value < value)
                    if (tmp.RightChild == null)
                    {
                        TreeNode newNode = new TreeNode() { Value = value };
                        tmp.RightChild = newNode;
                        return;
                    }
                    else
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                else if (tmp.LeftChild == null)
                {
                    TreeNode newNode = new TreeNode() { Value = value };
                    tmp.LeftChild = newNode;
                    return;
                }
                else
                {
                    tmp = tmp.LeftChild;
                    continue;
                }
        }

        public void PrintTree(TreeNode root, string space)
        {
            if (root != null)
            {
                PrintTree(root.RightChild, space + "   ");
                Console.WriteLine($"{space}{root.Value}");
                PrintTree(root.LeftChild, space + "   ");

            }
        }

        public TreeNode GetNodeByValueBFS(int value)
        {
            TreeNode tmp = head;
            var que = new Queue<TreeNode>();

            if (tmp == null)
                return tmp;
            que.Enqueue(tmp);

            Console.WriteLine("");
            Console.WriteLine("BFS");
            Console.WriteLine("=======");
            while (true)
            {
                foreach (var i in que)
                    Console.WriteLine(i.Value);
                Console.WriteLine("=======");
                if (que.Peek().Value == value)
                    return tmp;
                else
                {
                    que.Dequeue();
                    if (tmp.LeftChild != null)
                        que.Enqueue(tmp.LeftChild);
                    if (tmp.RightChild != null)
                        que.Enqueue(tmp.RightChild);
                    tmp = que.Peek();
                }
            }
        }

        public TreeNode GetNodeByValueDFS(int value)
        {
            TreeNode tmp = head;
            var stak = new Stack<TreeNode>();

            if (tmp == null)
                return tmp;
            stak.Push(tmp);

            Console.WriteLine("");
            Console.WriteLine("DFS");
            Console.WriteLine("=======");
            while (true)
            {
                foreach (var i in stak)
                    Console.WriteLine(i.Value);
                Console.WriteLine("=======");
                if (stak.Peek().Value == value)
                    return tmp;
                else
                {
                    if (tmp.LeftChild != null)
                    {
                        stak.Push(tmp.LeftChild);
                        tmp = stak.Peek();
                    }
                    else if (tmp.RightChild != null)
                    {
                        stak.Push(tmp.RightChild);
                        tmp = stak.Peek();
                    }
                    else
                    {
                        stak.Pop();
                        tmp = stak.Peek();
                    }
                        
                }
            }
        }
    }

        public class Program
    {
        static void Main(string[] args)
        {
            var binTr = new BinaryTree();

            binTr.AddItem(6);
            binTr.AddItem(2);
            binTr.AddItem(11);
            binTr.AddItem(3);
            binTr.AddItem(9);
            binTr.AddItem(30);

            binTr.PrintTree(BinaryTree.head, "");

            Console.WriteLine(binTr.GetNodeByValueBFS(3).Value);
            Console.WriteLine(binTr.GetNodeByValueDFS(3).Value);


        }
    }
}