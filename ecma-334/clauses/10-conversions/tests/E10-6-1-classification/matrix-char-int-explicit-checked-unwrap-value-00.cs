/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            char? input = (char)(0);
            int result = checked((int)input);
            Check(result==0, "nullable-char-int-explicit-checked-unwrap-0");
        }
        {
            char? input = (char)(65535);
            int result = checked((int)input);
            Check(result==65535, "nullable-char-int-explicit-checked-unwrap-1");
        }
        {
            char? input = (char)(1);
            int result = checked((int)input);
            Check(result==1, "nullable-char-int-explicit-checked-unwrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
