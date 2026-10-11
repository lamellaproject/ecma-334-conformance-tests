/*
Rules: E10-3-2-all-pairs; E10-3-2-short
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 5
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
            short input = (short)(-32768);
            long result = checked((long)input);
            Check(result==-32768L, "short-long-explicit-checked-variable-0");
        }
        {
            short input = (short)(32767);
            long result = checked((long)input);
            Check(result==32767L, "short-long-explicit-checked-variable-1");
        }
        {
            short input = (short)(0);
            long result = checked((long)input);
            Check(result==0L, "short-long-explicit-checked-variable-2");
        }
        {
            short input = (short)(1);
            long result = checked((long)input);
            Check(result==1L, "short-long-explicit-checked-variable-3");
        }
        {
            short input = (short)(-1);
            long result = checked((long)input);
            Check(result==-1L, "short-long-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
