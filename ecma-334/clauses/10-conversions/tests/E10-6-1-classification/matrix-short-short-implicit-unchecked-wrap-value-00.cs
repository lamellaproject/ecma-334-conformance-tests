/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            short input = (short)(-32768);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-short-short-implicit-unchecked-wrap-0");
        }
        {
            short input = (short)(32767);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-short-short-implicit-unchecked-wrap-1");
        }
        {
            short input = (short)(0);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-short-short-implicit-unchecked-wrap-2");
        }
        {
            short input = (short)(1);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-short-short-implicit-unchecked-wrap-3");
        }
        {
            short input = (short)(-1);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-short-short-implicit-unchecked-wrap-4");
        }
        {
            short input = (short)(-32767);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(-32767), "nullable-short-short-implicit-unchecked-wrap-5");
        }
        {
            short input = (short)(32766);
            short? result = unchecked(input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-short-short-implicit-unchecked-wrap-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
