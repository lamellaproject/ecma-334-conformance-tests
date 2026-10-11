/*
Rules: E12-20-3-5-orderby-first; E12-20-3-5-orderby-subsequent; E12-20-3-5-orderby-subsequent-descending; E12-20-1-body-orderby; E12-20-1-orderby-form; E12-20-1-orderings-form; E12-20-1-ordering-form; E12-20-1-ascending-form; E12-20-1-descending-form; E12-20-4-order-by-shape; E12-20-4-ordered-sequence-shape; E12-20-4-then-by-shape; E12-20-4-then-by-descending-shape
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: item + 3 descending
Into: item + 3 ascending
*/
using System;
delegate R Key<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Ordered<T> OrderBy<K>(Key<T, K> selector) { Program.trace += "A" + selector(Value); return new Ordered<T>(Value); }
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
        Ordered<int> result = from item in new Stream<int>(7) orderby item + 1, item + 2 ascending, item + 3 descending select item;
        Check(result.Value == 7, "ordered-source-result");
        Check(trace == "A8a9d10", "directions-keys-and-source-order");
        Stream<int> sequence = result;
        Check(object.ReferenceEquals(sequence, result), "ordered-sequence-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
