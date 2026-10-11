/*
Rules: E6-5-8-line-caller-info
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: #line 1
Into: #line 2
*/
using System;
using System.Runtime.CompilerServices;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Line([CallerLineNumber] int number = 0) { return number; }
    static string File([CallerFilePath] string name = "") { return name; }
    static void Main()
    {
        string original = File();
#line 1 "caller.origin"
        Check(Line() == 1, "caller-line-is-mapped");
        Check(File() != original, "caller-path-is-mapped-with-implementation-format");
#line default
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
