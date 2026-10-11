/*
Rules: E18-4-2-method-value-form; E18-4-2-nongeneric-header; E18-4-2-generic-header; E18-4-2-class-component-meaning; E18-4-1-member-method; E18-4-1-implicit-public; E18-4-6-member-access-form
Authority: ECMA-334 7th ed 18.4.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public T Echo<T>(T value) where T : class { return value; }
Into: public T Echo<T>(T value) where T : class { return null; }
*/
using System;
class MarkAttribute : Attribute { }
interface IRead
{
    [Mark] int Read(int start, int increment = 2);
    T Echo<T>(T value) where T : class;
    void Touch();
}
class Reader : IRead
{
    public int Calls;
    public int Read(int start, int increment) { return start + increment; }
    public T Echo<T>(T value) where T : class { return value; }
    public void Touch() { Calls++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Reader reader = new Reader();
        IRead view = reader;
        Check(view.Read(61) == 63, "interface-method-optional-parameter");
        Check(view.Echo("maple") == "maple", "generic-method-and-constraint");
        view.Touch();
        Check(reader.Calls == 1, "void-method-no-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
