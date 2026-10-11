/*
Rules: E19-4-member-scope; E19-4-simple-name-in-scope
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Copy = Original
Into: Copy = Program.Original
*/
using System;
class Program
{
    public const int Original = 99;
    enum Code { Original = 23, Copy = Original }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Code.Copy == 23, "enum-member-scope-precedes-containing-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
