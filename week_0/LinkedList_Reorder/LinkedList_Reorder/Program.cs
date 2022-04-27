using LinkedList_Reorder;

ListNode listNode = new ListNode();
Solution.AddNode(listNode, new ListNode(85));
Solution.AddNode(listNode, new ListNode(12));
Solution.AddNode(listNode, new ListNode(27));
Solution.AddNode(listNode, new ListNode(9));
Solution.AddNode(listNode, new ListNode(15));

ListNode newListNode = Solution.ReverseList(listNode);

Solution.PrintList(listNode);
Solution.PrintList(newListNode);

Console.ReadKey();
