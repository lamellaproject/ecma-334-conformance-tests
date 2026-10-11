/*
Rules: E19-2-generic-struct-nesting
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object item = Host<int>.Code.Mark
Into: object item = Host<long>.Code.Mark
*/
using System;
struct Host<T> { public enum Code { Mark = 7 } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object item = Host<int>.Code.Mark;
        Check(item is Host<int>.Code, "containing-struct-argument");
        Check(!(item is Host<long>.Code), "different-struct-construction-distinct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
