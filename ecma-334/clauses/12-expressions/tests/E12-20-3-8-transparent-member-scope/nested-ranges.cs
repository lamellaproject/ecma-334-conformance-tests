/*
Rules: E12-20-3-8-transparent-member-scope; E12-20-3-8-transparent-propagation; E12-20-3-8-transparent-member-declaration; E12-20-3-8-transparent-anonymous-type; E12-20-3-5-later-body-shape
Authority: ECMA-334 7th ed 12.20.3.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: let doubled = start * 2
Into: let doubled = start * 3
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
    public Stream<R> Select<R>(Unary<T, R> selector) { Program.trace += "S"; return new Stream<R>(Present ? selector(Value) : default(R), Present); }
    public Stream<T> Where(Unary<T, bool> predicate) { Program.trace += "W"; return new Stream<T>(Value, Present && predicate(Value)); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = from start in new Stream<int>(4, true)
                     let doubled = start * 2
                     from next in new Stream<int>(doubled + 3, true)
                     let combined = start + doubled + next
                     where start == 4 && doubled == 8 && next == 11 && combined == 23
                     select start * 1000 + doubled * 100 + next * 10 + combined;
        Check(result.Present, "nested-members-in-predicate");
        Check(result.Value == 4933, "all-nested-members-in-projection");
        Check(trace == "SMSWS", "transparent-members-propagate-through-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
