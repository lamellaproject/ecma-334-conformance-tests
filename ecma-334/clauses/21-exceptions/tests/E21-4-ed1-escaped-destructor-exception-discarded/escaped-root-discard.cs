/*
Rules: E21-4-ed1-escaped-destructor-exception-discarded
Authority: ECMA-334 1st ed 23.3
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Version-Witness: tests/E21-4-ed1-escaped-destructor-exception-discarded/escaped-root-discard.witness.cs.part
Mutate: ~Container()
Into: void ReleaseBody()
*/
// ECMA-334 1st ed 23.3, p. 308 (PDF p. 322), lines 16-17 discards the uncaught destructor
// exception. The checked body-entry flag separates a hosted scheduling prerequisite.
using System;
using System.Runtime.CompilerServices;
class Container
{
    ~Container()
    {
        Entry.entered = true;
        Entry.value = 83;
        throw new InvalidOperationException("escaped-root");
    }
}
class Entry
{
    public static volatile bool entered;
    public static volatile int value;
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Release() { new Container(); }
    public static int Main()
    {
        Release();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(entered, "hosted-destructor-entry");
        Check(value == 83, "survived-with-destructor-payload");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
