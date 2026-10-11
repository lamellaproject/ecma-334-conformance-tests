/*
Rules: E12-20-3-5-from-body-rewrite; E12-20-3-1-transparent-injection; E12-20-3-8-transparent-definition; E12-20-3-8-transparent-parameter-scope
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: from right in new Stream<int>(left + 4, true)
Into: from right in new Stream<int>(left + 5, true)
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Stream<T>
{
    public T Value;
    public bool Present;
    public Stream(T value, bool present) { Value = value; Present = present; }
    public Stream<R> SelectMany<U, R>(Unary<T, Stream<U>> source, Binary<T, U, R> result)
    {
        Program.trace += "M";
        var inner = source(Value);
        return new Stream<R>(result(Value, inner.Value), Present && inner.Present);
    }
    public Stream<T> Where(Unary<T, bool> predicate) { Program.trace += "W"; return new Stream<T>(Value, Present && predicate(Value)); }
    public Stream<R> Select<R>(Unary<T, R> selector) { Program.trace += "S"; return new Stream<R>(Present ? selector(Value) : default(R), Present); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = from left in new Stream<int>(3, true) from right in new Stream<int>(left + 4, true) where right - left == 4 select left * 10 + right;
        Check(result.Present && result.Value == 37, "transparent-pair-in-predicate-and-result");
        Check(trace == "MWS", "select-many-pair-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
