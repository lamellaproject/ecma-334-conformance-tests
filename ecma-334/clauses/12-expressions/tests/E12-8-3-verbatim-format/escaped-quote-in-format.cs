/*
Rules: E12-8-3-verbatim-format; E12-8-3-explicit-format; E12-8-3-verbatim-quote-escape
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $@"P{piece:A""B}Z"
Into: $@"P{piece:AB}Z"
*/
using System;
class Piece : IFormattable
{
    public string ToString(string format, IFormatProvider provider) { return format; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Piece piece = new Piece();
        string result = $@"P{piece:A""B}Z";
        Check(result == "PA\"BZ", "verbatim-format-token-decodes-escaped-quote");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
