/*
Rules: E12-8-17-void-type-object; E12-8-17-void-form; E12-8-17-void-distinct
Authority: ECMA-334 7th ed 12.8.17
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Type absent = typeof(void);
Into: Type absent = typeof(object);
*/
using System;
class Program
{
    public static void Empty() { }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type absent = typeof(void);
        Check(absent == typeof(Program).GetMethod("Empty").ReturnType, "void-is-absence-of-return-type");
        Check(absent != typeof(object) && absent != typeof(int) && absent != typeof(string), "void-distinct-from-value-and-reference-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
