/*
Rules: E7-5-3-protected-internal-domain; E7-5-2-protected-internal-modifiers; E7-5-2-class-member-access-kinds
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: protected internal int value = 79;
Into: protected int value = 79;
*/
using System;
#if LIBRARY
public class Root { protected internal int value = 79; }
public class LocalProbe { public static int Read() { return new Root().value; } }
#else
class Branch : Root { public int Read() { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(LocalProbe.Read() == 79, "same-program-nonderived-access");
        Check(new Branch().Read() == 79, "external-derived-type-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
