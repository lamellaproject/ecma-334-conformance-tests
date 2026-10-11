/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            ulong input = 0UL;
            char result = unchecked((char)input);
            Check(result==(char)(0), "ulong-char-explicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "ulong-char-explicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            char result = unchecked((char)input);
            Check(result==(char)(1), "ulong-char-explicit-unchecked-variable-2");
        }
        {
            ulong input = 65534UL;
            char result = unchecked((char)input);
            Check(result==(char)(65534), "ulong-char-explicit-unchecked-variable-3");
        }
        {
            ulong input = 65535UL;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "ulong-char-explicit-unchecked-variable-4");
        }
        {
            ulong input = 65536UL;
            char result = unchecked((char)input);
            Check(result==(char)(0), "ulong-char-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
