/*
Rules: E21-4-initialization-wrapper; E21-4-initialization-inner
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw Program.Original
Into: return
*/
using System;
class Broken
{
    static Broken() { throw Program.Original; }
    public static int Read() { return 17; }
}
class Program
{
    public static Exception Original = new Exception("constructor failure");
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception original = Original;
        bool wrapped = false, same = false;
        try { int result = Broken.Read(); }
        catch (TypeInitializationException caught) { wrapped = true; same = caught.InnerException == original; }
        catch (Exception) { }
        Check(wrapped, "constructor-failure-wrapped-at-call");
        Check(same, "constructor-wrapper-keeps-original");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
