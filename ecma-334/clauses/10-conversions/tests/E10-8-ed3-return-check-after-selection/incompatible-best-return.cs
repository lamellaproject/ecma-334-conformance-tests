/*
Rules: E10-8-ed3-return-check-after-selection
Authority: ECMA-334 3rd ed 14.5.10.3
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-8-ed3-return-check-after-selection/incompatible-best-return.cs.part
Mutate: static object Select(string word)
Into: static string Select(string word)
*/
// ECMA-334 3rd ed 14.5.10.3, p. 178 (PDF p. 198).
using System;
delegate string Reader(string word);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static object Select(string word) { return word; }
    static string Select(object word) { return (string)word; }
    static int Main()
    {
        Reader action = Select;
        Check(action("slate") == "slate", "method-return-selection");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
