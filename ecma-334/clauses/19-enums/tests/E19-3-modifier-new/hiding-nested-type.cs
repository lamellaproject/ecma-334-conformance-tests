/*
Rules: E19-3-modifier-new; E19-3-class-modifier-meaning
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new public enum Code
Into: new public class Code
*/
using System;
class Parent { public enum Code { Mark = 12 } }
class Child : Parent { new public enum Code { Mark = 13 } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Child.Code.Mark == 13, "new-enum-hides-base-name");
        Check((int)Parent.Code.Mark == 12, "base-enum-still-available");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
