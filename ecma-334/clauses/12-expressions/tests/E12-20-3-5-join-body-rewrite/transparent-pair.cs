/*
Rules: E12-20-3-5-join-body-rewrite
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: on left + 5 equals right
Into: on left + 4 equals right
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Stream<T>
{
    public T Value;
    public bool Present;
    public Stream(T value, bool present) { Value = value; Present = present; }
    public Stream<R> Join<U, K, R>(Stream<U> inner, Unary<T, K> outerKey, Unary<U, K> innerKey, Binary<T, U, R> result)
    {
        Program.trace += "J";
        bool match = Present && inner.Present && object.Equals(outerKey(Value), innerKey(inner.Value));
        return new Stream<R>(match ? result(Value, inner.Value) : default(R), match);
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
        var result = from left in new Stream<int>(7, true)
                     join right in new Stream<int>(12, true) on left + 5 equals right
                     where left == 7 && right == 12
                     select left * 10 + right;
        Check(result.Present && result.Value == 82, "joined-ranges-in-later-body");
        Check(trace == "JWS", "join-pair-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
