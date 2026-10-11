/*
Rules: E15-5-1-field-simple-name
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int Code = 233;
Into: int Other = 233;
*/
using System;
class Holder
{
    int Code = 233;
    public int Read() { return Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Read() == 233, "simple-name-field-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
