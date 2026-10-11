/*
Rules: E19-3-not-abstract
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Code()
Into: Code.Mark
*/
using System;
enum Code { Mark = 17 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code item = new Code();
        Check((int)item == 0, "enum-value-can-be-created");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
