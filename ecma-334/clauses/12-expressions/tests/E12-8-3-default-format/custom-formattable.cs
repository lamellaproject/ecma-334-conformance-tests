/*
Rules: E12-8-3-default-format; E12-8-3-string-call
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: $"P{piece}Z"
Into: $"P{piece:tag}Z"
*/
using System;
class Piece : IFormattable
{
    public int calls;
    public string ToString(string format, IFormatProvider provider) { calls++; return format == null ? "default" : "explicit"; }
    public override string ToString() { return "fallback"; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Piece piece = new Piece();
        string result = $"P{piece}Z";
        Check(result == "PdefaultZ", "omitted-format-uses-type-default-format");
        Check(piece.calls == 1, "string-format-dispatches-to-iformattable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
