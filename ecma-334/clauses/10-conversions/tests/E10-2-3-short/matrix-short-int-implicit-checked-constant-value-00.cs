/*
Rules: E10-2-3-short; E12-23-numeric
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
            const short input = (short)(-32768);
            int result = checked(input);
            Check(result==-32768, "short-int-implicit-checked-constant-0");
        }
        {
            const short input = (short)(32767);
            int result = checked(input);
            Check(result==32767, "short-int-implicit-checked-constant-1");
        }
        {
            const short input = (short)(0);
            int result = checked(input);
            Check(result==0, "short-int-implicit-checked-constant-2");
        }
        {
            const short input = (short)(1);
            int result = checked(input);
            Check(result==1, "short-int-implicit-checked-constant-3");
        }
        {
            const short input = (short)(-1);
            int result = checked(input);
            Check(result==-1, "short-int-implicit-checked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
