/*
Rules: E12-20-3-5-where-rewrite; E12-20-1-body-single-clause; E12-20-1-body-where; E12-20-1-where-form; E12-20-1-where-filter; E12-20-3-1-no-phase-revisit; E12-20-3-6-identity-select-removal; E12-20-4-where-shape
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: where item % 3 == 1
Into: where item % 3 == 2
*/
using System;
delegate R Visit<T, R>(T item);
class Stream<T>
{
    public T[] Items;
    public int Count;
    public Stream(T[] items, int count) { Items = items; Count = count; }
    public Stream<T> Where(Visit<T, bool> predicate)
    {
        Program.trace += "W";
        var items = new T[Count];
        int count = 0;
        for (int i = 0; i < Count; i++) if (predicate(Items[i])) items[count++] = Items[i];
        return new Stream<T>(items, count);
    }
    public Stream<R> Select<R>(Visit<T, R> selector)
    {
        Program.trace += "S";
        var items = new R[Count];
        for (int i = 0; i < Count; i++) items[i] = selector(Items[i]);
        return new Stream<R>(items, Count);
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var source = new Stream<int>(new int[] { 4, 8, 7 }, 3);
        var result = from item in source where item % 3 == 1 select item;
        Check(result.Count == 2, "filter-count");
        Check(result.Items[0] == 4 && result.Items[1] == 7, "predicate-range-values");
        Check(trace == "W", "identity-removed-without-phase-revisit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
