/*
Rules: E12-8-3-formattable; E12-8-3-format; E12-8-3-format-start; E12-8-3-format-initial-text; E12-8-3-format-following-text; E12-8-3-format-end
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: $@"A\{first}""M{second}Z"
Into: $@"A\{second}""M{first}Z"
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
        FormattableString result = $@"A\{first}""M{second}Z";
        Check(result.Format == "A\\{0}\"M{1}Z", "verbatim-composite-format-decodes-text-tokens");
        Check(result.GetArgument(0) == first && result.GetArgument(1) == second, "verbatim-arguments-in-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
