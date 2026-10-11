/*
Rules: E15-6-1-signature-components
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public int Read<T>() { return 2; }
Into: public int Read() { return 2; }
*/
using System;
class Holder
{
    public int Read() { return 1; }
    public int Read<T>() { return 2; }
    public int Read<T, U>() { return 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Read() == 1, "signature-with-no-type-parameters");
        Check(value.Read<int>() == 2, "signature-with-one-type-parameter");
        Check(value.Read<int, string>() == 3, "signature-with-two-type-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
