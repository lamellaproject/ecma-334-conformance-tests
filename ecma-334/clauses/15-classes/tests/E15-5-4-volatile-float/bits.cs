/*
Rules: E15-5-4-volatile-float
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile float Code;
Into: public volatile float Other;
*/
using System;
class Holder { public volatile float Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // Inspect the exact stored representation on the pinned IEEE single-precision target.
    unsafe static int Bits(float value) { return *(int*)&value; }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = 0.4375f;
        Check(Bits(value.Code) == 0x3ee00000, "volatile-float-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
