/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 13
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
            decimal? input = 0m;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-decimal-short-explicit-unchecked-unwrap-2");
        }
        {
            decimal? input = 1m;
            short result = unchecked((short)input);
            Check(result==(short)(1), "nullable-decimal-short-explicit-unchecked-unwrap-3");
        }
        {
            decimal? input = -1m;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nullable-decimal-short-explicit-unchecked-unwrap-4");
        }
        {
            decimal? input = 0.1m;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-decimal-short-explicit-unchecked-unwrap-5");
        }
        {
            decimal? input = -0.1m;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-decimal-short-explicit-unchecked-unwrap-6");
        }
        {
            decimal? input = 1E-28m;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-decimal-short-explicit-unchecked-unwrap-7");
        }
        {
            decimal? input = -1E-28m;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-decimal-short-explicit-unchecked-unwrap-8");
        }
        {
            decimal? input = -32768m;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-decimal-short-explicit-unchecked-unwrap-10");
        }
        {
            decimal? input = -32767m;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "nullable-decimal-short-explicit-unchecked-unwrap-11");
        }
        {
            decimal? input = 32766m;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nullable-decimal-short-explicit-unchecked-unwrap-12");
        }
        {
            decimal? input = 32767m;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-decimal-short-explicit-unchecked-unwrap-13");
        }
        {
            decimal? input = -32768.75m;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-decimal-short-explicit-unchecked-unwrap-15");
        }
        {
            decimal? input = 32767.75m;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-decimal-short-explicit-unchecked-unwrap-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
