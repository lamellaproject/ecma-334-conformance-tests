/*
Rules: E12-8-5-ed1-parenthesized-method-group
Authority: ECMA-334 1st ed 14.5.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-8-5-ed1-parenthesized-method-group/parenthesized-invocation.witness.cs.part
Mutate: ((Read))(32)
Into: Read(32)
*/
// ECMA-334 1st ed 14.5.3, p. 140 (PDF p. 154), lines 20-23. A parenthesized expression
// denoting a method group is a compile-time error, including when passed to a delegate
// constructor or enclosed in additional parentheses before invocation.
using System;
delegate int Reader(int value);
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
    static int Read(int value) { return value + 2; }
    static int Main()
    {
        Check(((Read))(32) == 34, "invocation-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
