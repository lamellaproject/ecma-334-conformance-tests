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
            int result = unchecked(input);
            Check(result==0, "char-int-implicit-unchecked-constant-0");
        }
        {
            const char input = (char)(65535);
            int result = unchecked(input);
            Check(result==65535, "char-int-implicit-unchecked-constant-1");
        }
        {
            const char input = (char)(1);
            int result = unchecked(input);
            Check(result==1, "char-int-implicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
