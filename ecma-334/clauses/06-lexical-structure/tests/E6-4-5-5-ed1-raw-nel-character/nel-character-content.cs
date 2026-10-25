/*
Rules: E6-4-5-5-ed1-raw-nel-character
Authority: ECMA-334 1st ed 9.4.4.4
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: tests/E6-4-5-5-ed1-raw-nel-character/nel-character-content.witness.cs.part
Mutate: \xC2\x85
Into: Z
*/
// ECMA-334 1st ed 9.4.4.4, p. 59 (PDF p. 73), line 28 permits raw NEL as a character.
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
        char value = '';
        Check((int)value == 133, "character-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
