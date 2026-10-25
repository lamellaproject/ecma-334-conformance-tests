/*
Rules: E12-8-4-ed1-invariant-simple-name
Authority: ECMA-334 1st ed 14.5.2.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-8-4-ed1-invariant-simple-name/invariant-switch.witness.cs.part
Mutate: = Read();
Into: = Entry.Read();
*/
// ECMA-334 1st ed 14.5.2.1, p. 139 (PDF p. 153), lines 23-26. Occurrences of one
// identifier as a simple name in expressions within its immediately enclosing block or
// switch block, including nested blocks, must denote one entity.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Read() { return 11; }
    static int Main()
    {
        int total = 0;
        int key = 1;
        switch (key)
        {
            case 1:
                total = Read();
                {
                    int Read = 7;
                    total += Read;
                }
                break;
        }
        Check(total == 18, "qualified-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
