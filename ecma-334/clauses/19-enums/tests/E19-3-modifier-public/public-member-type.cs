/*
Rules: E19-3-modifier-public; E19-3-optional-modifiers; E19-3-class-modifier-meaning
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public enum Code
Into: internal enum Code
*/
using System;
public enum Code { Mark = 8 }
public class Holder { public Code Value = Code.Mark; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Value == Code.Mark, "public-enum-can-be-public-member-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
