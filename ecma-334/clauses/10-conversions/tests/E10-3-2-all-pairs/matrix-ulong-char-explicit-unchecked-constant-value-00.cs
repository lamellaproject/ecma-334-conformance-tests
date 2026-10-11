/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong; E12-23-numeric
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
            const ulong input = 0UL;
            char result = unchecked((char)input);
            Check(result==(char)(0), "ulong-char-explicit-unchecked-constant-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "ulong-char-explicit-unchecked-constant-1");
        }
        {
            const ulong input = 1UL;
            char result = unchecked((char)input);
            Check(result==(char)(1), "ulong-char-explicit-unchecked-constant-2");
        }
        {
            const ulong input = 65534UL;
            char result = unchecked((char)input);
            Check(result==(char)(65534), "ulong-char-explicit-unchecked-constant-3");
        }
        {
            const ulong input = 65535UL;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "ulong-char-explicit-unchecked-constant-4");
        }
        {
            const ulong input = 65536UL;
            char result = unchecked((char)input);
            Check(result==(char)(0), "ulong-char-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
