/*
Rules: E7-5-3-public-top-level-domain; E7-5-3-top-level-member-definition; E7-5-2-public-modifier; E7-5-1-domain-access
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: public class Portal
Into: internal class Portal
*/
using System;
#if LIBRARY
public class Portal { public static int Read() { return 31; } }
public class LocalProbe { public static int Read() { return Portal.Read(); } }
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Portal.Read() == 31, "public-type-in-referencing-program");
        Check(LocalProbe.Read() == 31, "public-type-in-declaring-program");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
