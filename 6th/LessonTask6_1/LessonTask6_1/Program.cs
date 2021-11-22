using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask4_2
{
    public class Node 
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } = new List<Edge>();
    }

    public class Edge
    {
        public int Weight { get; set; }
        public Node Node { get; set; } 
    }

    public interface IGraph
    {
        Node GetNodeByValueBFS(int value); //получить узел графа по значению BFS
        Node GetNodeByValueDFS(int value, Node node); //получить узел графа по значению DFS
    }

    public class Graph : IGraph
    {
        public static Node head;

        public Node GetNodeByValueBFS(int value)
        {
            Node tmp = head;
            var que = new Queue<Node>();

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
                    if (tmp != head && que.Count != 0 && tmp.Edges != null)
                    {
                        foreach (Edge j in tmp.Edges)
                            if (j.Node != que.Peek())
                                que.Enqueue(j.Node);
                    }
                    else
                        foreach (Edge i in tmp.Edges)
                            que.Enqueue(i.Node);
                    tmp = que.Peek();
                }
            }
        }

        public Node GetNodeByValueDFS(int value, Node node)
        {
            Node tmp = node;
            var stak = new Stack<Node>();

            stak.Push(tmp);

            Console.WriteLine("");
            Console.WriteLine("DFS");
            Console.WriteLine("=======");
            while (true)
                if (tmp.Value == value)
                    return tmp;
                else if (stak.Peek().Edges.Count != 0)
                {
                    stak.Pop();
                    foreach (Edge i in tmp.Edges)
                        if (i.Node != tmp)
                            stak.Push(i.Node);
                    foreach(Node j in stak)
                        Console.WriteLine(j.Value);
                    Console.WriteLine("=======");
                    tmp = stak.Peek();
                }
                else
                {
                    stak.Pop();
                    tmp = stak.Peek();
                }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            var node1 = new Node();
            node1.Value = 1;
            var node2 = new Node();
            node2.Value = 2;
            var node3 = new Node();
            node3.Value = 3;
            var node4 = new Node();
            node4.Value = 4;
            var node5 = new Node();
            node5.Value = 5;
            var node6 = new Node();
            node6.Value = 6;

            Graph.head = node1;

            var edge1 = new Edge();
            edge1.Weight = 3;
            edge1.Node = node2;
            var edge2 = new Edge();
            edge2.Weight = 2;
            edge2.Node = node3;
            var edge3 = new Edge();
            edge3.Weight = 9;
            edge3.Node = node3;
            var edge4 = new Edge();
            edge4.Weight = 10;
            edge4.Node = node4;
            var edge5 = new Edge();
            edge5.Weight = 8;
            edge5.Node = node4;
            var edge6 = new Edge();
            edge6.Weight = 3;
            edge6.Node = node5;
            var edge7 = new Edge();
            edge7.Weight = 5;
            edge7.Node = node5;
            var edge8 = new Edge();
            edge8.Weight = 3;
            edge8.Node = node6;
            var edge9 = new Edge();
            edge9.Weight = 1;
            edge9.Node = node6;



            node1.Edges.Add(edge1);
            node1.Edges.Add(edge2);
            node2.Edges.Add(edge3);
            node2.Edges.Add(edge4);
            node3.Edges.Add(edge5);
            node3.Edges.Add(edge7);
            node4.Edges.Add(edge6);
            node4.Edges.Add(edge9);
            node5.Edges.Add(edge8);

            Console.WriteLine($"Needed value is {graph.GetNodeByValueBFS(5).Value}");
            Console.WriteLine($"Needed value is {graph.GetNodeByValueDFS(2, Graph.head).Value}");


        }
    }
}
