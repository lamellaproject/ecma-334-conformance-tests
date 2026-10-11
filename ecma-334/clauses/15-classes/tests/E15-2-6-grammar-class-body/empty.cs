/*
Rules: E15-2-6-grammar-class-body
Authority: ECMA-334 7th ed 15.2.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Empty { }
Into: class Empty
*/
using System;
class Empty { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Empty() != null, "class-body-permits-no-member-declarations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
