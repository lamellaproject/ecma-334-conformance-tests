/*
Rules: E12-20-3-5-orderby-first-descending; E12-20-4-order-by-descending-shape
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: item + 1 descending
Into: item + 1 ascending
*/
using System;
delegate R Key<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Ordered<T> OrderBy<K>(Key<T, K> selector) { Program.trace += "A" + selector(Value); return new Ordered<T>(Value); }
    public Ordered<T> OrderByDescending<K>(Key<T, K> selector) { Program.trace += "D" + selector(Value); return new Ordered<T>(Value); }
}
class Ordered<T> : Stream<T>
{
    public Ordered(T value) : base(value) { }
    public Ordered<T> ThenBy<K>(Key<T, K> selector) { Program.trace += "a" + selector(Value); return this; }
    public Ordered<T> ThenByDescending<K>(Key<T, K> selector) { Program.trace += "d" + selector(Value); return this; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = from item in new Stream<int>(4) orderby item + 1 descending, item + 2 descending, item + 3 ascending select item;
        Check(result.Value == 4, "descending-result");
        Check(trace == "D5d6a7", "descending-first-and-subsequent-methods");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
