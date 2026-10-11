/*
Rules: E10-3-2-all-pairs; E10-3-2-byte
Authority: ECMA-334 7th ed 10.3.2
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
            byte input = (byte)(0);
            decimal result = checked((decimal)input);
            Check(result==0m, "byte-decimal-explicit-checked-variable-0");
        }
        {
            byte input = (byte)(255);
            decimal result = checked((decimal)input);
            Check(result==255m, "byte-decimal-explicit-checked-variable-1");
        }
        {
            byte input = (byte)(1);
            decimal result = checked((decimal)input);
            Check(result==1m, "byte-decimal-explicit-checked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
