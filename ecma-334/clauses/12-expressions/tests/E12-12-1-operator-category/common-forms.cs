/*
Rules: E12-12-1-operator-category; E12-12-1-comparison-category; E12-12-1-form-shift; E12-12-1-form-less; E12-12-1-form-greater; E12-12-1-form-less-equal; E12-12-1-form-greater-equal; E12-12-1-form-is-type; E12-12-1-form-as; E12-12-1-form-relational; E12-12-1-form-equality; E12-12-1-form-inequality
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: Number(3) < Number(12)
Into: Number(3) > Number(12)
*/
using System;
class Program
{
    static int checks, failures;
    static int Number(int value) { return value; }
    static object Reference(object value) { return value; }
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Check(Number(3) < Number(12), "less");
        Check(Number(12) > Number(3), "greater");
        Check(Number(12) >= Number(3) << 1, "shift-before-relation");
        Check((Number(3) <= Number(12)) == (Number(12) != Number(3)), "equality-of-relations");
        Check((Number(3) == Number(12)) != (Number(12) >= Number(3)), "inequality-of-relations");
        Check(Reference("oak") is string, "is-type");
        Check(Reference("oak") as string == "oak", "as-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
