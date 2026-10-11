/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public float Value;
Into: public float Value = -0.0f;
*/
using System;
class Holder { public float Value; public static float Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // 8.3.3 specifies the all-zero default representation for simple types.
    unsafe static int Bits(float value) { return *(int*)&value; }
    static void Main()
    {
        Holder value = new Holder();
        Check(Bits(value.Value) == 0, "instance-float-default-bits");
        Check(Bits(Holder.Global) == 0, "static-float-default-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
