using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask2_1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class LinkedList : ILinkedList
    {
        Node startEl;
        Node endEl;
        int count;

        public int GetCount()
        {
            return count;
        }

        public void AddNode(int value)
        {
            Node newNode = new Node { Value = value };

            if (startEl == null)
                startEl = newNode;
            else
            {
                endEl.NextNode = newNode;
                newNode.PrevNode = endEl;
            }
            endEl = newNode;
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node { Value = value, PrevNode = node, NextNode = node.NextNode };
            node.NextNode = newNode;

            if (node == endEl)
            {
                endEl = newNode;
            }

            count++;
        }

        public void RemoveNode(int index)
        {
            Node curr = startEl;
            int i = 0;

            while (i <= index)
            {
                if (i == index)
                {
                    if (curr == startEl)
                    {
                        curr.NextNode.PrevNode = curr.PrevNode;
                        startEl = curr.NextNode;
                    }
                    else if (curr == endEl)
                    {
                        curr.PrevNode.NextNode = curr.NextNode;
                        endEl = curr.PrevNode;
                    }
                    else
                    {
                        curr.NextNode.PrevNode = curr.PrevNode;
                        curr.PrevNode.NextNode = curr.NextNode;
                    }
                    count--;                    
                }
                else
                    curr = curr.NextNode;
                i++;
            }
        }

        public void RemoveNode(Node node)
        {
            Node curr = startEl;

            while (true)
                if (curr == node)
                {
                    if (curr == startEl)
                    {
                        curr.NextNode.PrevNode = curr.PrevNode;
                        startEl = curr.NextNode;
                        count--;
                        break;
                    }
                    else if (curr == endEl)
                    {
                        curr.PrevNode.NextNode = curr.NextNode;
                        endEl = curr.PrevNode;
                        count--;
                        break;
                    }
                    else
                    {
                        curr.NextNode.PrevNode = curr.PrevNode;
                        curr.PrevNode.NextNode = curr.NextNode;
                        count--;
                        break;
                    }
                }
                else if (curr == endEl)
                {
                    Console.WriteLine("Element is not found");
                    break;
                }   
             
                curr = curr.NextNode;
        }

        public Node FindNode(int searchValue)
        {
            Node curr = startEl;

            while (true)
            {
                if (curr != endEl)
                {
                    if (curr.Value == searchValue)
                        return curr;
                    curr = curr.NextNode;
                }
                else
                {
                    curr = curr.NextNode;
                    return curr;
                }  
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

