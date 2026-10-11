/*
Rules: E22-1-custom-declarative-information; E22-1-attach-attributes; E22-2-1-new-attribute-kind; E22-2-1-optional-name-suffix
Authority: ECMA-334 7th ed 22.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: class LabelAttribute : Attribute
Into: class LabelAttribute : Exception
*/
using System;
class LabelAttribute : Attribute { }
[Label] class ShortName { }
[LabelAttribute] class FullName { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
