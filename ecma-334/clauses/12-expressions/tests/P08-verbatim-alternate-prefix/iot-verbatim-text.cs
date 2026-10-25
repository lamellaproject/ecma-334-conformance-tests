/*
Rules: P08-verbatim-alternate-prefix; E12-8-3-verbatim-quote-escape; E12-8-3-verbatim-open-brace-escape; E12-8-3-verbatim-close-brace-escape
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: @$"route\n\u0041 ""{tag}"" {{west}}"
Into: @"route\n\u0041 ""{tag}"" {{west}}"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string tag = "cedar";
        string text = @$"route\n\u0041 ""{tag}"" {{west}}";
        Check(text == "route\\n\\u0041 \"cedar\" {west}", "verbatim-contents");
        Check(text.IndexOf('\n') == -1, "literal-backslash");
        string empty = @$"";
        Check(empty.Length == 0, "empty-body");
        string braces = @$"{{}}";
        Check(braces == "{}", "no-hole-braces");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
