/*
Rules: E12-8-3-factory; E12-8-3-factory-result; E12-8-3-formattable-type; E12-8-3-formattable
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: IFormattable result = $"P{piece:tag}Z";
Into: IFormattable result = (string)$"P{piece:tag}Z";
*/
using System;
class Piece : IFormattable
{
    public int calls;
    public string format;
    public string ToString(string format, IFormatProvider provider) { calls++; this.format = format; return "piece"; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Piece piece = new Piece();
        IFormattable result = $"P{piece:tag}Z";
        Check(result is FormattableString, "iformattable-target-is-factory-formattable-string");
        Check(piece.calls == 0, "factory-preserves-argument-before-formatting");
        string text = result.ToString(null, null);
        Check(text == "PpieceZ", "formattable-result-can-be-formatted");
        Check(piece.calls == 1 && piece.format == "tag", "explicit-format-reaches-original-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
