/*
Rules: E15-6-1-signature-components
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Read(int first, int second) { return 2; }
Into: public int Read(int first) { return 2; }
*/
using System;
class Holder
{
    public int Read(int first) { return 1; }
    public int Read(int first, int second) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Read(0) == 1, "signature-with-one-formal-parameter");
        Check(value.Read(0, 0) == 2, "signature-with-two-formal-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
