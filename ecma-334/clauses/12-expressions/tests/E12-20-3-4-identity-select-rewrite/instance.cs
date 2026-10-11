/*
Rules: E12-20-3-4-identity-select-rewrite; E12-20-3-4-degenerate-definition; E12-20-1-query-form; E12-20-1-from-form; E12-20-1-body-form; E12-20-1-select-ending; E12-20-1-select-form; E12-20-1-from-range-variable; E12-20-3-1-instance-methods; E12-20-4-shape-support; E12-20-4-unary-function-shape; E12-20-4-select-shape; E12-20-4-alternative-delegate-types; E12-22-query-form; E12-22-non-assignment-form
Authority: ECMA-334 7th ed 12.20.3.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: from item in source select item
Into: source
*/
using System;
delegate R Map<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Stream<R> Select<R>(Map<T, R> selector)
    {
        Program.trace += "S";
        return new Stream<R>(selector(Value));
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var source = new Stream<int>(19);
        var result = from item in source select item;
        Check(result.Value == 19, "identity-value");
        Check(trace == "S", "identity-select-invoked");
        Check(!object.ReferenceEquals(result, source), "method-result-used");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
