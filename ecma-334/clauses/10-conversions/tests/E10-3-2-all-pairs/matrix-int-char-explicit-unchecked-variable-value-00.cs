/*
Rules: E10-3-2-all-pairs; E10-3-2-int
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 8
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
            int input = -2147483648;
            char result = unchecked((char)input);
            Check(result==(char)(0), "int-char-explicit-unchecked-variable-0");
        }
        {
            int input = 2147483647;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "int-char-explicit-unchecked-variable-1");
        }
        {
            int input = 0;
            char result = unchecked((char)input);
            Check(result==(char)(0), "int-char-explicit-unchecked-variable-2");
        }
        {
            int input = 1;
            char result = unchecked((char)input);
            Check(result==(char)(1), "int-char-explicit-unchecked-variable-3");
        }
        {
            int input = -1;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "int-char-explicit-unchecked-variable-4");
        }
        {
            int input = 65534;
            char result = unchecked((char)input);
            Check(result==(char)(65534), "int-char-explicit-unchecked-variable-5");
        }
        {
            int input = 65535;
            char result = unchecked((char)input);
            Check(result==(char)(65535), "int-char-explicit-unchecked-variable-6");
        }
        {
            int input = 65536;
            char result = unchecked((char)input);
            Check(result==(char)(0), "int-char-explicit-unchecked-variable-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
