/*
Rules: E12-20-3-6-select-rewrite; E12-20-1-result-shape; E12-20-3-1-method-translation; E12-20-3-1-regular-invocation-processing
Authority: ECMA-334 7th ed 12.20.3.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: select item > 6 ? "large" : "small"
Into: select item > 6 ? "small" : "large"
*/
using System;
delegate R Choose<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Stream<R> Select<R>(Choose<T, R> selector) { Program.calls++; return new Stream<R>(selector(Value)); }
}
class Program
{
    public static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stream<string> projected = from item in new Stream<int>(9) select item > 6 ? "large" : "small";
        var ordinary = new Stream<int>(9).Select(item => item > 6 ? "large" : "small");
        Check(projected.Value == "large" && projected.Value == ordinary.Value, "typed-projection");
        Check(calls == 2, "ordinary-and-translated-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
