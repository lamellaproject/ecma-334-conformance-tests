/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 10
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
            decimal input = 0m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-variable-2");
        }
        {
            decimal input = 1m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "decimal-ushort-explicit-checked-variable-3");
        }
        {
            decimal input = 0.1m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-variable-5");
        }
        {
            decimal input = -0.1m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-variable-6");
        }
        {
            decimal input = 1E-28m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-variable-7");
        }
        {
            decimal input = -1E-28m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-variable-8");
        }
        {
            decimal input = 65534m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "decimal-ushort-explicit-checked-variable-9");
        }
        {
            decimal input = 65535m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "decimal-ushort-explicit-checked-variable-10");
        }
        {
            decimal input = -0.75m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-variable-12");
        }
        {
            decimal input = 65535.75m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "decimal-ushort-explicit-checked-variable-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
