/*
Rules: E14-5-3-ambiguous-member-imports; E14-5-4-import-nested-types
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: reject
Version-Witness: tests/E14-5-3-ambiguous-member-imports/type-and-member-same-simple-name.witness.cs.part
Mutate: int value = Tag;
Into: int value = Signals.Tag;
*/
using System;

using static Catalog;
using static Signals;

class Catalog
{
    public class Tag
    {
        public readonly int Code;
        public Tag(int code) { Code = code; }
    }
}
class Signals
{
    public static int Tag = 19;
}

class Program
{

    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Tag marker = new Tag(7);
        int value = Tag;
        Check(marker.Code == 7, "imported-type");
        Check(value == 19, "imported-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
