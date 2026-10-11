/*
Rules: E12-20-3-2-continuation-rewrite; E12-20-3-2-no-later-continuations; E12-20-3-1-repeated-reduction; E12-20-1-continuation-form; E12-20-1-continuation-generator
Authority: ECMA-334 7th ed 12.20.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: into step where step > 5 select step * 3
Into: into step where step > 5 select step
*/
using System;
delegate R Map<T, R>(T item);
class Stream<T>
{
    public T Value;
    public bool Present;
    public Stream(T value, bool present) { Value = value; Present = present; }
    public Stream<R> Select<R>(Map<T, R> selector) { Program.trace += "S"; return new Stream<R>(Present ? selector(Value) : default(R), Present); }
    public Stream<T> Where(Map<T, bool> predicate) { Program.trace += "W"; return new Stream<T>(Value, Present && predicate(Value)); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = from item in new Stream<int>(4, true) select item + 2 into step where step > 5 select step * 3 into end select end - 1;
        Check(result.Present && result.Value == 17, "continuation-feeds-next-body");
        Check(trace == "SWSS", "all-continuations-reduced");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
