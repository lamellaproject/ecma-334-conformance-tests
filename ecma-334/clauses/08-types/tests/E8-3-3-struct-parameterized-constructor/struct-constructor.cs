/*
Rules: E8-3-3-struct-parameterized-constructor; E8-3-4-struct-instance-constructor-members; E8-3-4-struct-field-members; E8-3-4-struct-method-members; E8-3-4-struct-constant-members
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Value = input;
Into: Value = input + 1;
*/
using System;
struct Sample { public const int Bias = 29; public int Value; public Sample(int input) { Value = input; } public int Read() { return Value + Bias; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sample sample = new Sample(6);
        Check(sample.Read() == 35, "struct-members-and-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
