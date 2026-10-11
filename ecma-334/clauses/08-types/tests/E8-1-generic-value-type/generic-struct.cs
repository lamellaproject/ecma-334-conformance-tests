/*
Rules: E8-1-generic-value-type
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public T First;
Into: public object First;
*/
using System;
struct Pair<T, U> { public T First; public U Second; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair<int, string> pair = new Pair<int, string>();
        pair.First = 36; pair.Second = "ready";
        int result = pair.First;
        Check(result == 36 && pair.Second == "ready", "generic-value-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
