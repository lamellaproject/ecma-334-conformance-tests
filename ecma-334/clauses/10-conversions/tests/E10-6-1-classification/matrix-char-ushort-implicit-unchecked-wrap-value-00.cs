/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 4
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
            ushort? result = unchecked(input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-char-ushort-implicit-unchecked-wrap-0");
        }
        {
            char input = (char)(65535);
            ushort? result = unchecked(input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-char-ushort-implicit-unchecked-wrap-1");
        }
        {
            char input = (char)(1);
            ushort? result = unchecked(input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-char-ushort-implicit-unchecked-wrap-2");
        }
        {
            char input = (char)(65534);
            ushort? result = unchecked(input);
            Check(result.HasValue && result.Value==(ushort)(65534), "nullable-char-ushort-implicit-unchecked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
