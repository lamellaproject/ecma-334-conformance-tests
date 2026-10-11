/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            int? input = -2147483648;
            decimal result = checked((decimal)input);
            Check(result==-2147483648m, "nullable-int-decimal-explicit-checked-unwrap-0");
        }
        {
            int? input = 2147483647;
            decimal result = checked((decimal)input);
            Check(result==2147483647m, "nullable-int-decimal-explicit-checked-unwrap-1");
        }
        {
            int? input = 0;
            decimal result = checked((decimal)input);
            Check(result==0m, "nullable-int-decimal-explicit-checked-unwrap-2");
        }
        {
            int? input = 1;
            decimal result = checked((decimal)input);
            Check(result==1m, "nullable-int-decimal-explicit-checked-unwrap-3");
        }
        {
            int? input = -1;
            decimal result = checked((decimal)input);
            Check(result==-1m, "nullable-int-decimal-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
