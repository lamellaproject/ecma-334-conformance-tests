/*
Rules: E10-2-3-byte
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
            byte input = (byte)(0);
            int result = unchecked(input);
            Check(result==0, "byte-int-implicit-unchecked-variable-0");
        }
        {
            byte input = (byte)(255);
            int result = unchecked(input);
            Check(result==255, "byte-int-implicit-unchecked-variable-1");
        }
        {
            byte input = (byte)(1);
            int result = unchecked(input);
            Check(result==1, "byte-int-implicit-unchecked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
