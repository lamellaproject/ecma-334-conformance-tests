/*
Rules: E10-2-2-same; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.2
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
            const char input = (char)(0);
            char result = unchecked(input);
            Check(result==(char)(0), "char-char-implicit-unchecked-constant-0");
        }
        {
            const char input = (char)(65535);
            char result = unchecked(input);
            Check(result==(char)(65535), "char-char-implicit-unchecked-constant-1");
        }
        {
            const char input = (char)(1);
            char result = unchecked(input);
            Check(result==(char)(1), "char-char-implicit-unchecked-constant-2");
        }
        {
            const char input = (char)(65534);
            char result = unchecked(input);
            Check(result==(char)(65534), "char-char-implicit-unchecked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
