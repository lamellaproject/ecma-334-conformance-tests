/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
            long? input = 0L;
            char result = checked((char)input);
            Check(result==(char)(0), "nullable-long-char-explicit-checked-unwrap-2");
        }
        {
            long? input = 1L;
            char result = checked((char)input);
            Check(result==(char)(1), "nullable-long-char-explicit-checked-unwrap-3");
        }
        {
            long? input = 65534L;
            char result = checked((char)input);
            Check(result==(char)(65534), "nullable-long-char-explicit-checked-unwrap-5");
        }
        {
            long? input = 65535L;
            char result = checked((char)input);
            Check(result==(char)(65535), "nullable-long-char-explicit-checked-unwrap-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
