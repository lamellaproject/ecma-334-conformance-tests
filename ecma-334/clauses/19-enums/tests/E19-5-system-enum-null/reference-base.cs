/*
Rules: E19-5-system-enum-null; E19-5-system-enum-class
Authority: ECMA-334 7th ed 19.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Enum value = null
Into: Enum value = Code.Mark
*/
using System;
enum Code { Mark = 1 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Enum value = null;
        object root = value;
        Check(value == null, "enum-base-is-nullable-reference");
        Check(root == null, "null-reference-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
