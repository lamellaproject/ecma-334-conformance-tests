/*
Rules: E10-3-2-all-pairs; E10-3-2-float
Authority: ECMA-334 7th ed 10.3.2
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
            float input = 0.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "float-ushort-explicit-checked-variable-2");
        }
        {
            float input = -0.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "float-ushort-explicit-checked-variable-3");
        }
        {
            float input = 1.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "float-ushort-explicit-checked-variable-4");
        }
        {
            float input = 0.75f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "float-ushort-explicit-checked-variable-6");
        }
        {
            float input = -0.75f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "float-ushort-explicit-checked-variable-7");
        }
        {
            float input = 65534.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "float-ushort-explicit-checked-variable-11");
        }
        {
            float input = 65535.0f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "float-ushort-explicit-checked-variable-12");
        }
        {
            float input = 65535.75f;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "float-ushort-explicit-checked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
