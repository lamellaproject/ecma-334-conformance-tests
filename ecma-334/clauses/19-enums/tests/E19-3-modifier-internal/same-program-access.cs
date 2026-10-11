/*
Rules: E19-3-modifier-internal; E19-3-class-modifier-meaning
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal enum Code
Into: private enum Code
*/
using System;
class Holder { internal enum Code { Mark = 9 } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Holder.Code.Mark == 9, "internal-nested-enum-accessible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
