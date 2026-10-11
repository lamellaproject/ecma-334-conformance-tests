/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            int? input = -2147483648;
            int result = checked((int)input);
            Check(result==-2147483648, "nullable-int-int-explicit-checked-unwrap-0");
        }
        {
            int? input = 2147483647;
            int result = checked((int)input);
            Check(result==2147483647, "nullable-int-int-explicit-checked-unwrap-1");
        }
        {
            int? input = 0;
            int result = checked((int)input);
            Check(result==0, "nullable-int-int-explicit-checked-unwrap-2");
        }
        {
            int? input = 1;
            int result = checked((int)input);
            Check(result==1, "nullable-int-int-explicit-checked-unwrap-3");
        }
        {
            int? input = -1;
            int result = checked((int)input);
            Check(result==-1, "nullable-int-int-explicit-checked-unwrap-4");
        }
        {
            int? input = -2147483647;
            int result = checked((int)input);
            Check(result==-2147483647, "nullable-int-int-explicit-checked-unwrap-5");
        }
        {
            int? input = 2147483646;
            int result = checked((int)input);
            Check(result==2147483646, "nullable-int-int-explicit-checked-unwrap-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
