using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Reorder
{
    internal class Solution
    {

        public static ListNode ReverseList(ListNode head)
        {
            ListNode current = head, next = null;
            while (current != null)
            {
                ListNode tmp = current.next;
                current.next = next;
                next = current;
                current = tmp;
            }
            head = next;
            return head;
        }

        public static void AddNode(ListNode head, ListNode node)
        {
            if (head == null)
                head = node;
            else
            {
                ListNode temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
