using System;

public class IntNode
{
    private int value;
    private IntNode next;

    public IntNode(int value)
    {
        this.value = value;
        this.next = null;
    }

    public IntNode(int value, IntNode next)
    {
        this.value = value;
        this.next = next;
    }

    public int GetValue()
    {
        return this.value;
    }

    public IntNode GetNext()
    {
        return this.next;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public void SetNext(IntNode next)
    {
        this.next = next;
    }

    public bool HasNext()
    {
        return this.next != null;
    }

    public override string ToString()
    {
        return this.value.ToString();
    }
}

class Program
{
    // ===== Write these four functions =====

    // How many nodes are in the list?
    public static int CountList(IntNode lst)
    {
        // TODO
        return 0;
    }

    // The sum of the even numbers in the list.
    public static int SumEvenElements(IntNode lst)
    {
        // TODO
        return 0;
    }

    // Is value somewhere in the list?
    public static bool HasValue(IntNode lst, int value)
    {
        // TODO
        return false;
    }

    // The largest number in the list. The list is never empty.
    public static int FindMaximum(IntNode lst)
    {
        // TODO
        return 0;
    }

    // ===== Tests – don't change anything below this line =====

    static int passed = 0;
    static int total = 0;

    static void PrintList(IntNode lst)
    {
        Console.Write("[");
        while (lst != null)
        {
            Console.Write(lst.GetValue());
            if (lst.HasNext()) Console.Write(" -> ");
            lst = lst.GetNext();
        }
        Console.Write("]");
    }

    // A crash in one function prints CRASHED and the other tests still run.
    static void Check(string label, Func<object> run, object expected)
    {
        total++;
        string result;
        try
        {
            object actual = run();
            bool ok = actual.Equals(expected);
            if (ok) passed++;
            result = actual + "  (expected " + expected + ")  " + (ok ? "PASS" : "FAIL");
        }
        catch (Exception e)
        {
            result = "CRASHED: " + e.GetType().Name + "  (expected " + expected + ")  FAIL";
        }
        Console.WriteLine("  " + label.PadRight(22) + result);
    }

    static void TestList(string name, IntNode lst, int expCount, int expSum, int expMax)
    {
        Console.Write(name + ": ");
        PrintList(lst);
        Console.WriteLine();
        Check("CountList:", () => CountList(lst), expCount);
        Check("SumEvenElements:", () => SumEvenElements(lst), expSum);
        if (lst != null)
            Check("FindMaximum:", () => FindMaximum(lst), expMax);
        Console.WriteLine();
    }

    static void Main()
    {
        IntNode list1 = new IntNode(3, new IntNode(5, new IntNode(8, new IntNode(2, new IntNode(7)))));
        IntNode list2 = new IntNode(4);                                    // one node
        IntNode list3 = new IntNode(1, new IntNode(3, new IntNode(5)));    // no evens, max is last
        IntNode list4 = new IntNode(12, new IntNode(10, new IntNode(8,
                        new IntNode(6, new IntNode(4, new IntNode(2)))))); // all even, max is first
        IntNode list5 = null;                                              // empty list
        IntNode list6 = new IntNode(-4, new IntNode(7, new IntNode(0,
                        new IntNode(-2, new IntNode(-3)))));               // negatives and zero
        IntNode list7 = new IntNode(-5, new IntNode(-1, new IntNode(-9))); // all negative

        Console.WriteLine("===== CountList, SumEvenElements, FindMaximum =====\n");
        TestList("list1", list1, 5, 10, 8);
        TestList("list2", list2, 1, 4, 4);
        TestList("list3", list3, 3, 0, 5);
        TestList("list4", list4, 6, 42, 12);
        TestList("list5", list5, 0, 0, 0);   // FindMaximum skipped for empty list
        TestList("list6", list6, 5, -6, 7);
        TestList("list7", list7, 3, 0, -1);

        Console.WriteLine("===== HasValue =====\n");
        Check("list1 has 2:", () => HasValue(list1, 2), true);
        Check("list1 has 9:", () => HasValue(list1, 9), false);
        Check("list2 has 4:", () => HasValue(list2, 4), true);    // only node
        Check("list3 has 1:", () => HasValue(list3, 1), true);    // first node
        Check("list4 has 2:", () => HasValue(list4, 2), true);    // last node
        Check("list4 has 7:", () => HasValue(list4, 7), false);
        Check("list5 has 3:", () => HasValue(list5, 3), false);   // empty list
        Check("list6 has 0:", () => HasValue(list6, 0), true);
        Check("list7 has -9:", () => HasValue(list7, -9), true);

        Console.WriteLine();
        Console.WriteLine("===== Passed " + passed + " of " + total + " =====");
    }
}
