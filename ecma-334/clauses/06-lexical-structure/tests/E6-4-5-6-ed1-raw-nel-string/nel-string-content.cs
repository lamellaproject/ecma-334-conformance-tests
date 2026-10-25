/*
Rules: E6-4-5-6-ed1-raw-nel-string
Authority: ECMA-334 1st ed 9.4.4.5
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: tests/E6-4-5-6-ed1-raw-nel-string/nel-string-content.witness.cs.part
Mutate: \xC2\x85
Into: Z
*/
// ECMA-334 1st ed 9.4.4.5, p. 60 (PDF p. 74), line 27 permits raw NEL in a regular string.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        string value = "ab";
        Check(value.Length == 3 && value[1] == (char)133, "string-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
