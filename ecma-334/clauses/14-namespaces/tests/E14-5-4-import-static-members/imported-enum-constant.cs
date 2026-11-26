/*
Rules: E14-5-4-import-static-members
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Tone selected = Copper;
Into: Tone selected = Violet;
*/
using System;

using static Tone;

enum Tone { Copper = 17, Violet = 29 }

class Program
{
    static bool HasTag(int expected)
    {
        Tone selected = Copper;
        return (int)selected == expected;
    }

    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(HasTag(17), "unqualified-enum-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
