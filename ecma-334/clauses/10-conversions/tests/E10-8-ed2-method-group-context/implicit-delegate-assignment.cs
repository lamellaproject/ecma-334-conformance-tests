/*
Rules: E10-8-ed2-method-group-context
Authority: ECMA-334 2nd ed 14.1
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E10-8-ed2-method-group-context/implicit-delegate-assignment.cs.part
Mutate: Reader reader = Advance;
Into: Reader reader = new Reader(Advance);
*/
// ECMA-334 2nd ed 14.1, p. 123 (PDF p. 139).
using System;
delegate int Reader(int value);
class Program
{
    static int checks, failures;
    static int Advance(int value) { return value + 11; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main(string[] arguments)
    {
        Reader reader = Advance;
        int input = arguments.Length + 31;
        Check(reader(input) == input + 11, "delegate-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
