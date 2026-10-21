using System;
using System.Collections.Generic;

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
    // ===== Write these functions =====

    // 1. Count the nodes in the list.
    public static int CountList(IntNode lst)
    {
        // TODO
        return 0;
    }

    // 2. The sum of the even numbers in the list.
    public static int SumEvenElements(IntNode lst)
    {
        // TODO
        return 0;
    }

    // 3. true if x is somewhere in the list, otherwise false.
    public static bool HasValue(IntNode lst, int x)
    {
        // TODO
        return false;
    }

    // 4. The largest number in the list. The list is never empty.
    public static int FindMaximum(IntNode lst)
    {
        // TODO
        return 0;
    }

    // 5. Add 1 to the value in every node.
    public static void IncrementAll(IntNode lst)
    {
        // TODO
    }

    // 6. Add a new node with val at the end of the list. The list is never empty.
    public static void AddLast(IntNode lst, int val)
    {
        // TODO
    }

    // 7. Remove the first node that holds x. If x is not in the list, change nothing.
    //    Return the head of the list (it changes if x was in the first node).
    public static IntNode RemoveFirst(IntNode lst, int x)
    {
        // TODO
        return null;
    }

    // 8. Remove every node that holds an even number. Return the head of the list.
    public static IntNode RemoveEvens(IntNode lst)
    {
        // TODO
        return null;
    }

    // 9. true if every number is smaller than the one after it, otherwise false.
    //    An empty list and a list with one node are sorted.
    public static bool IsSorted(IntNode lst)
    {
        // TODO
        return false;
    }

    // 10. chain1 and chain2 are sorted from small to large. Return a NEW sorted
    //     list with all their numbers. Don't change chain1 or chain2.
    public static IntNode Merge(IntNode chain1, IntNode chain2)
    {
        // TODO
        return null;
    }

    // 11a. Return a NEW list with the same numbers in reverse order.
    //      Don't change the original list.
    public static IntNode ReverseCopy(IntNode lst)
    {
        // TODO
        return null;
    }

    // 11b. Challenge: reverse the list without creating any new nodes.
    //      Change the links so each node points to the one that was before it.
    //      Return the new head.
    public static IntNode Reverse(IntNode lst)
    {
        // TODO
        return null;
    }

    // 12. The length of the longest run of neighbouring nodes with the same
    //     value. For [1 -> 2 -> 2 -> 2 -> 3 -> 3] the answer is 3.
    public static int LongestRun(IntNode lst)
    {
        // TODO
        return 0;
    }

    // ===== Tests – don't change anything below this line =====

    static int passed = 0;
    static int total = 0;
    static string section;
    static List<string> summary = new List<string>();
    static int sectionPassed;
    static int sectionTotal;

    static IntNode L(params int[] values)
    {
        IntNode lst = null;
        for (int i = values.Length - 1; i >= 0; i--)
            lst = new IntNode(values[i], lst);
        return lst;
    }

    static string Show(IntNode lst)
    {
        string s = "[";
        int count = 0;
        while (lst != null)
        {
            if (count == 20)
                return s + "... never ends]";
            s += lst.GetValue();
            if (lst.HasNext()) s += " -> ";
            lst = lst.GetNext();
            count++;
        }
        return s + "]";
    }

    static string Text(object x)
    {
        if (x == null) return "[]";
        if (x is IntNode) return Show((IntNode)x);
        if (x is int[]) return Show(L((int[])x));
        if (x is bool) return (bool)x ? "true" : "false";
        return x.ToString();
    }

    static void Section(string name)
    {
        EndSection();
        section = name;
        sectionPassed = 0;
        sectionTotal = 0;
        Console.WriteLine();
        Console.WriteLine("===== " + name + " =====");
    }

    static void EndSection()
    {
        if (section != null)
            summary.Add("  " + section.PadRight(22) + sectionPassed + " of " + sectionTotal);
    }

    // A crash in one function prints CRASHED and the other tests still run.
    static void Check(string call, Func<object> run, object expected)
    {
        total++;
        sectionTotal++;
        string exp = Text(expected);
        string result;
        bool ok;
        try
        {
            string actual = Text(run());
            ok = actual == exp;
            result = actual;
        }
        catch (Exception e)
        {
            ok = false;
            result = "CRASHED: " + e.GetType().Name;
        }
        if (ok)
        {
            passed++;
            sectionPassed++;
        }
        Console.WriteLine((ok ? "  PASS  " : "  FAIL  ") + call + "  ->  " + result
                          + (ok ? "" : "    (expected " + exp + ")"));
    }

    static void TestCount(int[] v, int expected)
    {
        Check("CountList(" + Text(v) + ")", () => CountList(L(v)), expected);
    }

    static void TestSumEven(int[] v, int expected)
    {
        Check("SumEvenElements(" + Text(v) + ")", () => SumEvenElements(L(v)), expected);
    }

    static void TestHasValue(int[] v, int x, bool expected)
    {
        Check("HasValue(" + Text(v) + ", " + x + ")", () => HasValue(L(v), x), expected);
    }

    static void TestMax(int[] v, int expected)
    {
        Check("FindMaximum(" + Text(v) + ")", () => FindMaximum(L(v)), expected);
    }

    static void TestIncrement(int[] v, int[] expected)
    {
        Check("IncrementAll(" + Text(v) + ")", () =>
        {
            IntNode lst = L(v);
            IncrementAll(lst);
            return lst;
        }, expected);
    }

    static void TestAddLast(int[] v, int val, int[] expected)
    {
        Check("AddLast(" + Text(v) + ", " + val + ")", () =>
        {
            IntNode lst = L(v);
            AddLast(lst, val);
            return lst;
        }, expected);
    }

    static void TestRemoveFirst(int[] v, int x, int[] expected)
    {
        Check("RemoveFirst(" + Text(v) + ", " + x + ")", () => RemoveFirst(L(v), x), expected);
    }

    static void TestRemoveEvens(int[] v, int[] expected)
    {
        Check("RemoveEvens(" + Text(v) + ")", () => RemoveEvens(L(v)), expected);
    }

    static void TestIsSorted(int[] v, bool expected)
    {
        Check("IsSorted(" + Text(v) + ")", () => IsSorted(L(v)), expected);
    }

    static void TestMerge(int[] a, int[] b, int[] expected)
    {
        Check("Merge(" + Text(a) + ", " + Text(b) + ")", () =>
        {
            IntNode chain1 = L(a);
            IntNode chain2 = L(b);
            IntNode result = Merge(chain1, chain2);
            if (Show(chain1) != Text(a)) return "changed chain1 to " + Show(chain1);
            if (Show(chain2) != Text(b)) return "changed chain2 to " + Show(chain2);
            return result;
        }, expected);
    }

    static void TestReverseCopy(int[] v, int[] expected)
    {
        Check("ReverseCopy(" + Text(v) + ")", () =>
        {
            IntNode lst = L(v);
            IntNode result = ReverseCopy(lst);
            if (Show(lst) != Text(v)) return "changed the original list to " + Show(lst);
            return result;
        }, expected);
    }

    static void TestReverse(int[] v, int[] expected)
    {
        Check("Reverse(" + Text(v) + ")", () =>
        {
            IntNode lst = L(v);
            List<IntNode> nodes = new List<IntNode>();
            for (IntNode p = lst; p != null; p = p.GetNext())
                nodes.Add(p);
            IntNode result = Reverse(lst);
            if (Show(result) != Text(expected)) return result;
            IntNode q = result;
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                if (q != nodes[i]) return Show(result) + " but made new nodes";
                q = q.GetNext();
            }
            return result;
        }, expected);
    }

    static void TestLongestRun(int[] v, int expected)
    {
        Check("LongestRun(" + Text(v) + ")", () => LongestRun(L(v)), expected);
    }

    static void Main()
    {
        int[] empty = new int[0];

        Section("1. CountList");
        TestCount(new[] { 3, 5, 8, 2, 7 }, 5);
        TestCount(new[] { 4 }, 1);
        TestCount(new[] { 12, 10, 8, 6, 4, 2 }, 6);
        TestCount(empty, 0);

        Section("2. SumEvenElements");
        TestSumEven(new[] { 3, 5, 8, 2, 7 }, 10);
        TestSumEven(new[] { 4 }, 4);
        TestSumEven(new[] { 1, 3, 5 }, 0);
        TestSumEven(new[] { 12, 10, 8, 6, 4, 2 }, 42);
        TestSumEven(new[] { -4, 7, 0, -2, -3 }, -6);
        TestSumEven(empty, 0);

        Section("3. HasValue");
        TestHasValue(new[] { 3, 5, 8, 2, 7 }, 2, true);
        TestHasValue(new[] { 3, 5, 8, 2, 7 }, 9, false);
        TestHasValue(new[] { 4 }, 4, true);
        TestHasValue(new[] { 1, 3, 5 }, 1, true);
        TestHasValue(new[] { 1, 3, 5 }, 5, true);
        TestHasValue(new[] { -4, 7, 0, -2, -3 }, 0, true);
        TestHasValue(empty, 3, false);

        Section("4. FindMaximum");
        TestMax(new[] { 3, 5, 8, 2, 7 }, 8);
        TestMax(new[] { 4 }, 4);
        TestMax(new[] { 1, 3, 5 }, 5);
        TestMax(new[] { 12, 10, 8, 6, 4, 2 }, 12);
        TestMax(new[] { -5, -1, -9 }, -1);

        Section("5. IncrementAll");
        TestIncrement(new[] { 3, 5, 8 }, new[] { 4, 6, 9 });
        TestIncrement(new[] { 4 }, new[] { 5 });
        TestIncrement(new[] { -1, 0, -7 }, new[] { 0, 1, -6 });

        Section("6. AddLast");
        TestAddLast(new[] { 3, 5, 8 }, 1, new[] { 3, 5, 8, 1 });
        TestAddLast(new[] { 4 }, 9, new[] { 4, 9 });
        TestAddLast(new[] { 2, 2 }, 2, new[] { 2, 2, 2 });

        Section("7. RemoveFirst");
        TestRemoveFirst(new[] { 3, 5, 8, 2 }, 8, new[] { 3, 5, 2 });
        TestRemoveFirst(new[] { 3, 5, 8, 2 }, 3, new[] { 5, 8, 2 });
        TestRemoveFirst(new[] { 3, 5, 8, 2 }, 2, new[] { 3, 5, 8 });
        TestRemoveFirst(new[] { 3, 5, 3, 5 }, 5, new[] { 3, 3, 5 });
        TestRemoveFirst(new[] { 3, 5, 8, 2 }, 9, new[] { 3, 5, 8, 2 });
        TestRemoveFirst(new[] { 4 }, 4, empty);
        TestRemoveFirst(empty, 4, empty);

        Section("8. RemoveEvens");
        TestRemoveEvens(new[] { 3, 5, 8, 2, 7 }, new[] { 3, 5, 7 });
        TestRemoveEvens(new[] { 2, 4, 1, 6 }, new[] { 1 });
        TestRemoveEvens(new[] { 1, 3, 5 }, new[] { 1, 3, 5 });
        TestRemoveEvens(new[] { 12, 10, 8 }, empty);
        TestRemoveEvens(new[] { -4, 7, 0, -2, -3 }, new[] { 7, -3 });
        TestRemoveEvens(empty, empty);

        Section("9. IsSorted");
        TestIsSorted(new[] { 1, 2, 3 }, true);
        TestIsSorted(new[] { -3, 0, 4, 10 }, true);
        TestIsSorted(new[] { 1, 3, 2 }, false);
        TestIsSorted(new[] { 2, 1 }, false);
        TestIsSorted(new[] { 1, 2, 2 }, false);
        TestIsSorted(new[] { 5 }, true);
        TestIsSorted(empty, true);

        Section("10. Merge");
        TestMerge(new[] { 1, 3, 5 }, new[] { 2, 4, 6 }, new[] { 1, 2, 3, 4, 5, 6 });
        TestMerge(new[] { 5, 6 }, new[] { 1, 2 }, new[] { 1, 2, 5, 6 });
        TestMerge(new[] { 1, 1, 4 }, new[] { 1, 3 }, new[] { 1, 1, 1, 3, 4 });
        TestMerge(empty, new[] { 1, 2 }, new[] { 1, 2 });
        TestMerge(new[] { 1, 2 }, empty, new[] { 1, 2 });
        TestMerge(empty, empty, empty);

        Section("11a. ReverseCopy");
        TestReverseCopy(new[] { 1, 2, 3 }, new[] { 3, 2, 1 });
        TestReverseCopy(new[] { 1, 2 }, new[] { 2, 1 });
        TestReverseCopy(new[] { 7 }, new[] { 7 });
        TestReverseCopy(empty, empty);

        Section("11b. Reverse");
        TestReverse(new[] { 1, 2, 3 }, new[] { 3, 2, 1 });
        TestReverse(new[] { 1, 2 }, new[] { 2, 1 });
        TestReverse(new[] { 7 }, new[] { 7 });
        TestReverse(empty, empty);

        Section("12. LongestRun");
        TestLongestRun(new[] { 1, 2, 2, 2, 3, 3 }, 3);
        TestLongestRun(new[] { 1, 2, 3 }, 1);
        TestLongestRun(new[] { 5, 5, 5 }, 3);
        TestLongestRun(new[] { 4, 4, 1, 2 }, 2);
        TestLongestRun(new[] { 1, 2, 2 }, 2);
        TestLongestRun(new[] { 3, 1, 3 }, 1);
        TestLongestRun(new[] { 7 }, 1);
        TestLongestRun(empty, 0);

        EndSection();
        Console.WriteLine();
        Console.WriteLine("===== Score =====");
        foreach (string line in summary)
            Console.WriteLine(line);
        Console.WriteLine();
        Console.WriteLine("  Passed " + passed + " of " + total);
    }
}
