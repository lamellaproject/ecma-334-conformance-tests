/*
Rules: E10-2-3-short
Authority: ECMA-334 7th ed 10.2.3
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
            int result = unchecked(input);
            Check(result==-32768, "short-int-implicit-unchecked-variable-0");
        }
        {
            short input = (short)(32767);
            int result = unchecked(input);
            Check(result==32767, "short-int-implicit-unchecked-variable-1");
        }
        {
            short input = (short)(0);
            int result = unchecked(input);
            Check(result==0, "short-int-implicit-unchecked-variable-2");
        }
        {
            short input = (short)(1);
            int result = unchecked(input);
            Check(result==1, "short-int-implicit-unchecked-variable-3");
        }
        {
            short input = (short)(-1);
            int result = unchecked(input);
            Check(result==-1, "short-int-implicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
