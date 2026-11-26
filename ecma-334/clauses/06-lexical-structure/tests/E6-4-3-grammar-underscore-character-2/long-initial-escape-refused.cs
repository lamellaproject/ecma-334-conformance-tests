/*
Rules: E6-4-3-grammar-underscore-character-2
Authority: ECMA-334 6th ed 6.4.3
Version: 6
Expected: reject
Version-Witness: tests/E6-4-3-grammar-underscore-character-2/long-initial-escape-refused.witness.cs.part
Mutate: \U0000005Foffset
Into: \u005Foffset
*/
using System;


class Program
{
    static int Read(int \U0000005Foffset)
    {
        return _offset;
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
        Check(Read(13) == 13, "escaped-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
