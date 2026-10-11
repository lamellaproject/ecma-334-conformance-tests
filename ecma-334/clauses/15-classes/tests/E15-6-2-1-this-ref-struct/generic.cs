/*
Rules: E15-6-2-1-this-ref-struct
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: this ref T target
Into: this T target
*/
using System;
static class Extensions
{
    public static void Replace<T>(this ref T target, T value) where T : struct { target = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 11;
        value.Replace(19);
        Check(value == 19, "struct-constrained-this-ref-extension-aliases-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
