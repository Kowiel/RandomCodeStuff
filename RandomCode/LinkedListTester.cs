using System;
using System.Collections.Generic;
using System.Linq;

public static class LinkedListTester
{
    public static ListNode FromArray(int[] values)
    {
        if (values == null || values.Length == 0)
            return null;

        ListNode dummy = new ListNode();
        ListNode current = dummy;

        foreach (int value in values)
        {
            current.next = new ListNode(value);
            current = current.next;
        }

        return dummy.next;
    }

    public static int[] ToArray(ListNode head)
    {
        List<int> values = new List<int>();

        while (head != null)
        {
            values.Add(head.val);
            head = head.next;
        }

        return values.ToArray();
    }

    public static string ToArrayString(ListNode head)
    {
        return "[" + string.Join(",", ToArray(head)) + "]";
    }

    public static void Print(ListNode head)
    {
        Console.WriteLine(ToArrayString(head));
    }
}