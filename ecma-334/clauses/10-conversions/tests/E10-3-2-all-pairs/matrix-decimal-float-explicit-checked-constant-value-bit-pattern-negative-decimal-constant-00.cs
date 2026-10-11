/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 7
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            const decimal input = -79228162514264337593543950335m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==4018143232U, "decimal-float-explicit-checked-constant-0");
        }
        {
            const decimal input = -1m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "decimal-float-explicit-checked-constant-4");
        }
        {
            const decimal input = -0.1m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3184315597U, "decimal-float-explicit-checked-constant-6");
        }
        {
            const decimal input = -1E-28m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2432534454U, "decimal-float-explicit-checked-constant-8");
        }
        {
            const decimal input = -16777217m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "decimal-float-explicit-checked-constant-12");
        }
        {
            const decimal input = -16777216m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "decimal-float-explicit-checked-constant-13");
        }
        {
            const decimal input = -16777215m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "decimal-float-explicit-checked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
