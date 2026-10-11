/*
Rules: E12-20-3-5-group-join-body-rewrite
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: on left + 10 equals right into matches
Into: on left + 11 equals right into matches
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Stream<T>
{
    public T Value;
    public bool Present;
    public Stream(T value, bool present) { Value = value; Present = present; }
    public Stream<R> GroupJoin<U, K, R>(Stream<U> inner, Unary<T, K> outerKey, Unary<U, K> innerKey, Binary<T, Stream<U>, R> result)
    {
        Program.trace += "G";
        bool match = inner.Present && object.Equals(outerKey(Value), innerKey(inner.Value));
        return new Stream<R>(result(Value, new Stream<U>(inner.Value, match)), Present);
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
        var result = from left in new Stream<int>(3, true)
                     join right in new Stream<int>(13, true) on left + 10 equals right into matches
                     where matches.Present && left == 3
                     select matches.Value + left;
        Check(result.Present && result.Value == 16, "outer-and-group-in-later-body");
        Check(trace == "GWS", "group-join-pair-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
