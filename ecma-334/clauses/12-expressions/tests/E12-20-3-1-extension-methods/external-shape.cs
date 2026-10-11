/*
Rules: E12-20-3-1-extension-methods; E12-20-4-shape-definition
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: select item + 12
Into: select item - 12
*/
using System;
delegate R Pick<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    private void Select() { }
}
static class Extensions
{
    public static Stream<R> Select<T, R>(this Stream<T> source, Pick<T, R> selector)
    {
        Program.trace += "E";
        return new Stream<R>(selector(source.Value));
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stream<int> result = from item in new Stream<int>(3) select item + 12;
        Check(result.Value == 15, "extension-selector");
        Check(trace == "E", "accessible-extension-shape");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
