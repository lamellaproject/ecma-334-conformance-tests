/*
Rules: E6-3-3-string-literal-no-comments
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: "/* alpha
Into: "// alpha
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string block = "/* alpha */";
        string line = @"// beta /* */";
        Check(block.Length == 11 && block[0] == '/' && block[1] == '*', "regular-block-marker");
        Check(block[9] == '*' && block[10] == '/', "regular-end-marker");
        Check(line.Length == 13 && line[0] == '/' && line[1] == '/', "verbatim-line-marker");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
