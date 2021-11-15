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
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(TreeNode root, string space); //вывести дерево в консоль
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

    public class BinaryTree : ITree
    {
        public static TreeNode head;

        public TreeNode GetRoot()
        {
            if (head == null)
                return null;
            return head;
        }

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

        public void RemoveItem(int value)
        {
            TreeNode curr;
            TreeNode tmp = head;

            if (tmp.Value == value)
                if (tmp.RightChild == null && tmp.LeftChild == null)
                    tmp = null;
                else if (tmp.RightChild == null)
                {
                    tmp.Value = tmp.LeftChild.Value;
                    tmp.RightChild = tmp.LeftChild.RightChild;
                    tmp.LeftChild = tmp.LeftChild.LeftChild;
                }
                else if (tmp.LeftChild == null)
                {
                    tmp.Value = tmp.RightChild.Value;
                    tmp.RightChild = tmp.RightChild.RightChild;
                    tmp.LeftChild = tmp.RightChild.LeftChild;
                }
                else
                {
                    curr = tmp.RightChild;
                    if (curr.LeftChild != null)
                    {
                        while (curr.LeftChild != null)
                            curr = curr.LeftChild;
                        tmp.Value = curr.LeftChild.Value;
                        curr.LeftChild = null;
                    }
                    else
                    {
                        tmp.Value = tmp.RightChild.Value;
                        tmp.RightChild = tmp.RightChild.RightChild;

                    }


                }
        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode tmp = head;

            while (true)
                if (value > tmp.Value)
                    tmp = tmp.RightChild;
                else if (value < tmp.Value)
                    tmp = tmp.LeftChild;
                else
                    return tmp;
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
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var binTr = new BinaryTree();
            var rand = new Random();

            binTr.AddItem(6);
            binTr.AddItem(2);
            binTr.AddItem(11);
            binTr.AddItem(3);
            binTr.AddItem(9);
            binTr.AddItem(30);

            binTr.PrintTree(BinaryTree.head, "");

        }
    }
}
