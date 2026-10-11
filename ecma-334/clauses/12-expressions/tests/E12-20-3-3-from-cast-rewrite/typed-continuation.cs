/*
Rules: E12-20-3-3-from-cast-rewrite; E12-20-3-3-no-later-explicit-types; E12-20-3-1-phase-order; E12-20-4-cast-shape; E12-20-4-sequence-shape
Authority: ECMA-334 7th ed 12.20.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: from long item in source
Into: from int item in source
*/
using System;
delegate R Project<T, R>(T item);
class Source
{
    object value;
    public Source(object value) { this.value = value; }
    public Stream<T> Cast<T>() { Program.trace += "C"; return new Stream<T>((T)value); }
}
class Stream<T> : Source
{
    public T Value;
    public Stream(T value) : base(value) { Value = value; }
    public Stream<R> Select<R>(Project<T, R> selector) { Program.trace += "S"; return new Stream<R>(selector(Value)); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Source Make() { trace += "E"; return new Source(37L); }
    static void Main()
    {
        var source = Make();
        Stream<long> result = from long item in source select item into copy select copy;
        Check(result.Value == 37L, "cast-range-type-and-value");
        Check(trace == "ECSS", "cast-before-both-identity-projections");
        Source baseResult = result;
        Check(object.ReferenceEquals(baseResult, result), "generic-sequence-base-shape");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
