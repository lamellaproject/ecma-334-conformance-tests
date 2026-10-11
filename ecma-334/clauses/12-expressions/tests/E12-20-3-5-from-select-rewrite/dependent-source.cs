/*
Rules: E12-20-3-5-from-select-rewrite; E12-20-1-body-from; E12-20-4-binary-function-shape; E12-20-4-select-many-shape
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: from right in Next(left + 5)
Into: from right in Next(left + 6)
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Stream<R> SelectMany<U, R>(Unary<T, Stream<U>> source, Binary<T, U, R> result)
    {
        Program.trace += "M";
        var inner = source(Value);
        return new Stream<R>(result(Value, inner.Value));
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Stream<int> First() { trace += "E"; return new Stream<int>(6); }
    static Stream<int> Next(int value) { trace += "N"; return new Stream<int>(value); }
    static int Combine(int left, int right) { trace += "R"; return left * 10 + right; }
    static void Main()
    {
        Stream<int> result = from left in First() from right in Next(left + 5) select Combine(left, right);
        Check(result.Value == 71, "both-result-selector-parameters");
        Check(trace == "EMNR", "dependent-source-selector");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
