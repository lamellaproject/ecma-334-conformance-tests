/*
Rules: E12-8-16-6-ed1-exact-method-compatibility
Authority: ECMA-334 1st ed 14.5.10.3
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: tests/E12-8-16-6-ed1-exact-method-compatibility/delegate-exact-base-method.witness.cs.part
Mutate: new ReadText(leaf.Read)
Into: new ReadText(leaf.Other)
*/
// ECMA-334 1st ed 14.5.10.3, p. 149 (PDF p. 163), lines 44-45; continuation p. 150 (PDF p.
// 164), lines 1-3. Creating a delegate from a method group chooses its unique exactly
// compatible method: parameter types, modifiers and return type must match.
using System;
delegate int ReadText(string text);
class Root
{
    public int Read(string text) { return 41; }
}
class Leaf : Root
{
    public int Read(object text) { return 99; }
    public int Other(string text) { return 99; }
}
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
    static int Main()
    {
        Leaf leaf = new Leaf();
        ReadText reader = new ReadText(leaf.Read);
        Check(reader("tile") == 41, "exact-base-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
