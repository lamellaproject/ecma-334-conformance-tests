/*
Rules: E7-1-library-compilation; E7-1-compilation-mode-selection; E7-1-library-no-entry
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: public static int Read() { return 17; }
Into: public static int Read() { return 19; }
*/
using System;
#if LIBRARY
public class LibraryValue
{
    public static int Read() { return 17; }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(LibraryValue.Read() == 17, "compiled-library-used");
        Check(typeof(LibraryValue).Assembly.EntryPoint == null, "library-has-no-entry");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
