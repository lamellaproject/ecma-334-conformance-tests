/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            char? input = (char)(0);
            char? result = checked(input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-char-char-implicit-checked-lift-0");
        }
        {
            char? input = (char)(65535);
            char? result = checked(input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-char-char-implicit-checked-lift-1");
        }
        {
            char? input = (char)(1);
            char? result = checked(input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-char-char-implicit-checked-lift-2");
        }
        {
            char? input = (char)(65534);
            char? result = checked(input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-char-char-implicit-checked-lift-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
