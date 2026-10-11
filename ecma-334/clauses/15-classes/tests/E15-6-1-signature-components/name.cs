/*
Rules: E15-6-1-signature-components
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Inspect(int value) { return 2; }
Into: public int Read(int value) { return 2; }
*/
using System;
class Holder
{
    public int Read(int value) { return 1; }
    public int Inspect(int value) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Read(0) == 1, "first-method-name-selects-first-signature");
        Check(value.Inspect(0) == 2, "other-method-name-selects-other-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
