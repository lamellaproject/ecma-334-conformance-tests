/*
Rules: E12-6-3-10-lower-array-interface
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Enumerate(values)
Into: Enumerate(new object[1])
*/
using System;
using System.Collections.Generic;
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Enumerate<T>(IEnumerable<T> x) { return new Result<T>(); }
    static Result<T> Collect<T>(ICollection<T> x) { return new Result<T>(); }
    static Result<T> List<T>(IList<T> x) { return new Result<T>(); }
    static Result<T> ReadList<T>(IReadOnlyList<T> x) { return new Result<T>(); }
    static Result<T> ReadCollection<T>(IReadOnlyCollection<T> x) { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] values = { "x" };
        Result<string> a = Enumerate(values), b = Collect(values), c = List(values);
        Result<string> d = ReadList(values), e = ReadCollection(values);
        Check(a != null, "array-to-enumerable-element-inference");
        Check(b != null, "array-to-collection-element-inference");
        Check(c != null, "array-to-list-element-inference");
        Check(d != null, "array-to-readonly-list-element-inference");
        Check(e != null, "array-to-readonly-collection-element-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
