/*
Rules: E15-6-1-grammar-ref-method-modifier-form-6
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int Next() { return ++Calls; }
Into: public int Next() { return ++Calls; }
*/
using System;
class Holder
{
    public static int Calls;
    public static int Next() { return ++Calls; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Next() == 1, "static-method-first-class-call");
        Check(Holder.Next() == 2 && Holder.Calls == 2, "static-method-acts-on-class-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
