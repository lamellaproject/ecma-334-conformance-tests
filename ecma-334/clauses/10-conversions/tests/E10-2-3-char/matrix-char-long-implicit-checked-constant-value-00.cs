/*
Rules: E10-2-3-char; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 3
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
            const char input = (char)(0);
            long result = checked(input);
            Check(result==0L, "char-long-implicit-checked-constant-0");
        }
        {
            const char input = (char)(65535);
            long result = checked(input);
            Check(result==65535L, "char-long-implicit-checked-constant-1");
        }
        {
            const char input = (char)(1);
            long result = checked(input);
            Check(result==1L, "char-long-implicit-checked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
