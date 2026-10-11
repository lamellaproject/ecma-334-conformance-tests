/*
Rules: E12-8-3-explicit-format; E12-8-3-regular-format
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: $"P{piece:tag}Z"
Into: $"P{piece}Z"
*/
using System;
class Piece : IFormattable
{
    public int calls;
    public string ToString(string format, IFormatProvider provider) { calls++; return format ?? "default"; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Piece piece = new Piece();
        string result = $"P{piece:tag}Z";
        Check(result == "PtagZ", "regular-explicit-format-passed-to-argument");
        Check(piece.calls == 1, "regular-explicit-format-invoked-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
