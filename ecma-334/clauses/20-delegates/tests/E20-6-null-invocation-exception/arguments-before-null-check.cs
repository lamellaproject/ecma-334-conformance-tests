/*
Rules: E20-6-null-invocation-exception
Authority: ECMA-334 7th ed 20.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Notice notice = null;
Into: Notice notice = Touch;
*/
using System;
delegate void Notice(int value);
class Program
{
    static int checks, failures;
    static int arguments;
    static int Argument() { arguments++; return 37; }
    static void Touch(int value) { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice notice = null;
        bool caught = false;
        try { notice(Argument()); }
        catch (NullReferenceException) { caught = true; }
        catch (Exception) { Check(false, "wrong-null-delegate-exception-type"); }
        Check(caught, "null-delegate-invocation-type");
        Check(arguments == 1, "argument-before-null-check");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
