/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            ushort? input = (ushort)(0);
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-ushort-float-implicit-checked-lift-0");
        }
        {
            ushort? input = (ushort)(65535);
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1199570688U, "nullable-ushort-float-implicit-checked-lift-1");
        }
        {
            ushort? input = (ushort)(1);
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-ushort-float-implicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
