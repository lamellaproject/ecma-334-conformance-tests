/*
Rules: E15-6-1-signature-type-parameter-position; E15-6-1-signature-components
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Read<T, U>(U first, T second)
Into: public int Read<T, U>(T first, U second)
*/
using System;
class Holder
{
    public int Read<T, U>(T first, U second) { return 1; }
    public int Read<T, U>(U first, T second) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Read<int, string>(7, "x") == 1, "signature-uses-first-then-second-type-parameter");
        Check(value.Read<int, string>("y", 9) == 2, "signature-uses-second-then-first-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
