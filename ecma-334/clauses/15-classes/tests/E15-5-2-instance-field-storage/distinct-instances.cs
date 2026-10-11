/*
Rules: E15-5-2-instance-field-storage
Authority: ECMA-334 7th ed 15.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public int Code;
Into: public static int Code;
*/
using System;
class Holder
{
    public int Code;
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
        first.Store(1021);
        second.Store(1031);
        Check(first.Read() == 1021, "first-instance-own-field");
        Check(second.Read() == 1031, "second-instance-own-field");
        first.Store(1033);
        Check(first.Read() == 1033, "first-instance-update");
        Check(second.Read() == 1031, "second-instance-unaffected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
