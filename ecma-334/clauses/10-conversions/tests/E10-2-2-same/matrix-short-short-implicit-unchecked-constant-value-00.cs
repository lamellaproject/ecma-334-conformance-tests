/*
Rules: E10-2-2-same; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.2
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
            const short input = (short)(-32768);
            short result = unchecked(input);
            Check(result==(short)(-32768), "short-short-implicit-unchecked-constant-0");
        }
        {
            const short input = (short)(32767);
            short result = unchecked(input);
            Check(result==(short)(32767), "short-short-implicit-unchecked-constant-1");
        }
        {
            const short input = (short)(0);
            short result = unchecked(input);
            Check(result==(short)(0), "short-short-implicit-unchecked-constant-2");
        }
        {
            const short input = (short)(1);
            short result = unchecked(input);
            Check(result==(short)(1), "short-short-implicit-unchecked-constant-3");
        }
        {
            const short input = (short)(-1);
            short result = unchecked(input);
            Check(result==(short)(-1), "short-short-implicit-unchecked-constant-4");
        }
        {
            const short input = (short)(-32767);
            short result = unchecked(input);
            Check(result==(short)(-32767), "short-short-implicit-unchecked-constant-5");
        }
        {
            const short input = (short)(32766);
            short result = unchecked(input);
            Check(result==(short)(32766), "short-short-implicit-unchecked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
