/*
Rules: E7-5-3-public-nested-domain; E7-5-3-nested-member-definition; E7-5-1-accessibility-composition
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: public class Nested
Into: private class Nested
*/
using System;
#if LIBRARY
public class Envelope { public class Nested { public static int Read() { return 61; } } }
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Envelope.Nested.Read() == 61, "public-nested-type-through-public-envelope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
