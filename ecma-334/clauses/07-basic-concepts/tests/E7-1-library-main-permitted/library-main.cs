/*
Rules: E7-1-library-main-permitted; E7-1-library-no-entry
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: public static int Main() { return 23; }
Into: public static int Main() { return 29; }
*/
using System;
#if LIBRARY
public class LibraryEntry
{
    public static int Main() { return 23; }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(LibraryEntry.Main() == 23, "library-main-ordinary-call");
        Check(typeof(LibraryEntry).Assembly.EntryPoint == null, "main-did-not-create-entry");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
