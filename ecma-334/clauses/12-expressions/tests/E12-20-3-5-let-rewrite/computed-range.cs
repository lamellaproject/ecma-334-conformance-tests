/*
Rules: E12-20-3-5-let-rewrite; E12-20-1-body-let; E12-20-1-let-form; E12-20-1-let-range-variable; E12-20-1-body-append-clause
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: let computed = item * 4
Into: let computed = item * 5
*/
using System;
delegate R Transform<T, R>(T item);
class Stream<T>
{
    public T Value;
    public bool Present;
    public Stream(T value, bool present) { Value = value; Present = present; }
    public Stream<R> Select<R>(Transform<T, R> selector) { Program.trace += "S"; return new Stream<R>(Present ? selector(Value) : default(R), Present); }
    public Stream<T> Where(Transform<T, bool> predicate) { Program.trace += "W"; return new Stream<T>(Value, Present && predicate(Value)); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = from item in new Stream<int>(5, true) let computed = item * 4 where computed == 20 select item + computed;
        Check(result.Present && result.Value == 25, "let-keeps-old-and-computed-ranges");
        Check(trace == "SWS", "let-projection-before-predicate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
