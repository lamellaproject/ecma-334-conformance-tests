/*
Rules: E12-20-1-orderby-order
Authority: ECMA-334 7th ed 12.20.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: orderby item / 10, item % 10 ascending
Into: orderby item / 10, -(item % 10) ascending
*/
using System;
delegate int Rank(int item);
class Source
{
    public int[] Items;
    public Source(int[] items) { Items = items; }
    public Ordered OrderBy(Rank selector) { Program.trace += "A"; return new Ordered(Items, selector); }
}
class Ordered : Source
{
    int[] primary;
    public Ordered(int[] source, Rank selector) : base(new int[source.Length])
    {
        primary = new int[source.Length];
        for (int i = 0; i < source.Length; i++) { Items[i] = source[i]; primary[i] = selector(source[i]); }
        for (int i = 0; i < Items.Length; i++) for (int j = i + 1; j < Items.Length; j++)
            if (primary[i] > primary[j]) Swap(i, j);
    }
    void Swap(int first, int second)
    {
        int value = Items[first]; Items[first] = Items[second]; Items[second] = value;
        int key = primary[first]; primary[first] = primary[second]; primary[second] = key;
    }
    public Ordered ThenBy(Rank selector)
    {
        Program.trace += "a";
        for (int i = 0; i < Items.Length; i++) for (int j = i + 1; j < Items.Length; j++)
            if (primary[i] == primary[j] && selector(Items[i]) > selector(Items[j])) Swap(i, j);
        return this;
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = from item in new Source(new int[] { 24, 11, 21 }) orderby item / 10, item % 10 ascending select item;
        Check(result.Items[0] == 11 && result.Items[1] == 21 && result.Items[2] == 24, "primary-then-secondary-criteria");
        Check(trace == "Aa", "ordering-calls-without-final-identity-select");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
