/*
Rules: E7-1-main-ordinary-invocation; E7-1-ordinary-main-null-argument; E7-1-ordinary-main-null-element; E7-1-ordinary-main-return
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Main(new string[] { null })
Into: Main(new string[] { "leaf" })
*/
using System;
class Program
{
    static bool ordinary;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Main(string[] args)
    {
        if (ordinary) return args == null ? 41 : (args[0] == null ? 43 : 47);
        ordinary = true;
        int nullArray = Main(null);
        int nullElement = Main(new string[] { null });
        Check(nullArray == 41, "ordinary-main-null-array-return");
        Check(nullElement == 43, "ordinary-main-null-element-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures;
    }
}
