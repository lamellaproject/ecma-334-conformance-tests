/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            ushort input = (ushort)(0);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-ushort-int-explicit-checked-wrap-0");
        }
        {
            ushort input = (ushort)(65535);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==65535, "nullable-ushort-int-explicit-checked-wrap-1");
        }
        {
            ushort input = (ushort)(1);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-ushort-int-explicit-checked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
