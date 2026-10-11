/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 11
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
            long? input = long.MinValue;
            int result = unchecked((int)input);
            Check(result==0, "nullable-long-int-explicit-unchecked-unwrap-0");
        }
        {
            long? input = 9223372036854775807L;
            int result = unchecked((int)input);
            Check(result==-1, "nullable-long-int-explicit-unchecked-unwrap-1");
        }
        {
            long? input = 0L;
            int result = unchecked((int)input);
            Check(result==0, "nullable-long-int-explicit-unchecked-unwrap-2");
        }
        {
            long? input = 1L;
            int result = unchecked((int)input);
            Check(result==1, "nullable-long-int-explicit-unchecked-unwrap-3");
        }
        {
            long? input = -1L;
            int result = unchecked((int)input);
            Check(result==-1, "nullable-long-int-explicit-unchecked-unwrap-4");
        }
        {
            long? input = -2147483649L;
            int result = unchecked((int)input);
            Check(result==2147483647, "nullable-long-int-explicit-unchecked-unwrap-5");
        }
        {
            long? input = -2147483648L;
            int result = unchecked((int)input);
            Check(result==-2147483648, "nullable-long-int-explicit-unchecked-unwrap-6");
        }
        {
            long? input = -2147483647L;
            int result = unchecked((int)input);
            Check(result==-2147483647, "nullable-long-int-explicit-unchecked-unwrap-7");
        }
        {
            long? input = 2147483646L;
            int result = unchecked((int)input);
            Check(result==2147483646, "nullable-long-int-explicit-unchecked-unwrap-8");
        }
        {
            long? input = 2147483647L;
            int result = unchecked((int)input);
            Check(result==2147483647, "nullable-long-int-explicit-unchecked-unwrap-9");
        }
        {
            long? input = 2147483648L;
            int result = unchecked((int)input);
            Check(result==-2147483648, "nullable-long-int-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
