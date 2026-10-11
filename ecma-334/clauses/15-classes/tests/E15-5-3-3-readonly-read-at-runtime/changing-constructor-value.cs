/*
Rules: E15-5-3-3-readonly-read-at-runtime
Authority: ECMA-334 7th ed 15.5.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int Read() { return Code; }
Into: public static int Read() { return 211; }
*/
using System;
class Holder
{
    public static readonly int Code = 211;
    public static readonly int Before = Read();
    public static readonly int After;
    static Holder() { Code = 223; After = Read(); }
    public static int Read() { return Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Before == 211, "readonly-read-before-constructor-reassignment");
        Check(Holder.After == 223, "readonly-read-after-constructor-reassignment");
        Check(Holder.Read() == 223, "readonly-read-after-class-initialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
