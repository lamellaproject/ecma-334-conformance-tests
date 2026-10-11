/*
Rules: E12-8-3-formattable; E12-8-3-formattable-type; E12-8-3-factory; E12-8-3-factory-result; E12-8-3-format-first-argument; E12-8-3-one-argument-per-interpolation; E12-8-3-format; E12-8-3-format-start; E12-8-3-format-initial-text; E12-8-3-placeholder-order; E12-8-3-placeholder-open; E12-8-3-placeholder-index; E12-8-3-placeholder-alignment; E12-8-3-placeholder-format; E12-8-3-placeholder-close; E12-8-3-format-following-text; E12-8-3-format-end; E12-8-3-argument-sequence
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: $"P{first,5:X}M{second,-4}Z"
Into: $"P{second,5:X}M{first,-4}Z"
*/
using System;
class Piece { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Piece first = new Piece(), second = new Piece();
        FormattableString result = $"P{first,5:X}M{second,-4}Z";
        Check(result.Format == "P{0,5:X}M{1,-4}Z", "composite-format-text-index-alignment-and-format");
        Check(result.ArgumentCount == 2, "one-argument-per-interpolation");
        Check(result.GetArgument(0) == first, "first-interpolation-is-argument-zero");
        Check(result.GetArgument(1) == second, "second-interpolation-is-argument-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
