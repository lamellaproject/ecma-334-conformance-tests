/*
Rules: E13-10-6-propagation-typed-catch-match; E13-11-catch-base-type-match; E13-11-catch-same-type-match
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: catch (T caught)
Into: catch (Other caught)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Base : Exception { }
    class Specific : Base { }
    class Other : Exception { }
    static int selected;
    static Exception Handle<T>(T exception) where T : Exception
    {
        try { throw exception; }
        catch (T caught) { selected++; return caught; }
        catch (Exception caught) { return caught; }
    }
    static void Main()
    {
        Specific expected = new Specific();
        Exception same = Handle<Specific>(expected);
        Exception derived = Handle<Base>(expected);
        Check(same == expected && selected == 2, "type-parameter-runtime-match");
        Check(derived == expected, "derived-exception-matches-base-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
