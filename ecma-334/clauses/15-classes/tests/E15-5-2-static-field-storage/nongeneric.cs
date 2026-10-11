/*
Rules: E15-5-2-static-field-storage
Authority: ECMA-334 7th ed 15.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public static int Code;
Into: public int Code;
*/
using System;
class Holder
{
    public static int Code;
    public void Store(int code) { Code = code; }
    public int Read() { return Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder first = new Holder(), second = new Holder();
        first.Store(1039);
        Check(first.Read() == 1039, "static-field-through-first-instance");
        Check(second.Read() == 1039, "static-field-shared-with-second-instance");
        second.Store(1049);
        Check(first.Read() == 1049, "static-update-visible-in-first-instance");
        Check(second.Read() == 1049, "static-update-visible-in-second-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
