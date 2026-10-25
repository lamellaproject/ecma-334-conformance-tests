/*
Rules: E21-4-ed1-escaped-destructor-exception-discarded; E21-4-ed1-escaped-destructor-calls-base
Authority: ECMA-334 1st ed 23.3
Version: ISO-1
Expected: run
Stdout: "ANCESTOR\nOK 2"
Diagnostic: none
Version-Witness: tests/E21-4-ed1-escaped-destructor-exception-discarded/escaped-derived-base.witness.cs.part
Mutate: class Descendant : Ancestor
Into: class Descendant
*/
// ECMA-334 1st ed 23.3, p. 308 (PDF p. 322), lines 14-17 requires base continuation after
// this escaped throw. The flushed marker separates base entry from end-of-chain discard.
// Explicit GC requests/waits provide the pinned hosted scheduling prerequisite.
using System;
using System.Runtime.CompilerServices;
class Ancestor
{
    ~Ancestor()
    {
        Entry.baseEntered = true;
        Console.WriteLine("ANCESTOR");
        Console.Out.Flush();
    }
}
class Descendant : Ancestor
{
    ~Descendant()
    {
        Entry.derivedEntered = true;
        throw new InvalidOperationException("escaped-chain");
    }
}
class Entry
{
    public static volatile bool derivedEntered;
    public static volatile bool baseEntered;
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Release() { new Descendant(); }
    public static int Main()
    {
        Release();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(derivedEntered, "hosted-derived-entry");
        Check(baseEntered, "escaped-destructor-base-entry");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
