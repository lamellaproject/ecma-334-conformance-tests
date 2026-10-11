/*
Rules: E10-2-3-char
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
            char input = (char)(0);
            decimal result = unchecked(input);
            Check(result==0m, "char-decimal-implicit-unchecked-variable-0");
        }
        {
            char input = (char)(65535);
            decimal result = unchecked(input);
            Check(result==65535m, "char-decimal-implicit-unchecked-variable-1");
        }
        {
            char input = (char)(1);
            decimal result = unchecked(input);
            Check(result==1m, "char-decimal-implicit-unchecked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
