/*
Rules: E10-3-2-all-pairs; E10-3-2-short; E12-23-numeric
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
            const short input = (short)(-32768);
            decimal result = checked((decimal)input);
            Check(result==-32768m, "short-decimal-explicit-checked-constant-0");
        }
        {
            const short input = (short)(32767);
            decimal result = checked((decimal)input);
            Check(result==32767m, "short-decimal-explicit-checked-constant-1");
        }
        {
            const short input = (short)(0);
            decimal result = checked((decimal)input);
            Check(result==0m, "short-decimal-explicit-checked-constant-2");
        }
        {
            const short input = (short)(1);
            decimal result = checked((decimal)input);
            Check(result==1m, "short-decimal-explicit-checked-constant-3");
        }
        {
            const short input = (short)(-1);
            decimal result = checked((decimal)input);
            Check(result==-1m, "short-decimal-explicit-checked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
