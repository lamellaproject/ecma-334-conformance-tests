/*
Rules: E15-6-1-signature-components
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Read(long value) { return 2; }
Into: public int Read(int value) { return 2; }
*/
using System;
class Holder
{
    public int Read(int value) { return 1; }
    public int Read(long value) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Read(11) == 1, "int-formal-parameter-signature");
        Check(value.Read(11L) == 2, "long-formal-parameter-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
