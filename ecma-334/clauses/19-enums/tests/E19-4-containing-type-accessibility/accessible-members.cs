/*
Rules: E19-4-containing-type-accessibility
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public enum Code
Into: private enum Code
*/
using System;
class Holder { public enum Code { Mark = 29 } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Holder.Code.Mark == 29, "member-access-through-accessible-enum");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
