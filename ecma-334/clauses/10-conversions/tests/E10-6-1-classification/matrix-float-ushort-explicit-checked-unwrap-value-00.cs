/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 8
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
            float? input = 0.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "nullable-float-ushort-explicit-checked-unwrap-2");
        }
        {
            float? input = -0.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "nullable-float-ushort-explicit-checked-unwrap-3");
        }
        {
            float? input = 1.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "nullable-float-ushort-explicit-checked-unwrap-4");
        }
        {
            float? input = 0.75f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "nullable-float-ushort-explicit-checked-unwrap-6");
        }
        {
            float? input = -0.75f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "nullable-float-ushort-explicit-checked-unwrap-7");
        }
        {
            float? input = 65534.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "nullable-float-ushort-explicit-checked-unwrap-11");
        }
        {
            float? input = 65535.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "nullable-float-ushort-explicit-checked-unwrap-12");
        }
        {
            float? input = 65535.75f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "nullable-float-ushort-explicit-checked-unwrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
