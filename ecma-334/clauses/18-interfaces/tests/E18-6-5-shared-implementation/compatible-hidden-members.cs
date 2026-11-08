/*
Rules: E18-6-5-shared-implementation
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public int Read() { return 67; }
Into: public int Read() { return 69; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    interface IRoot { int Read(); }
    interface IBranch : IRoot { new int Read(); }
    class Shared : IBranch { public int Read() { return 67; } }
    class Separate : IBranch
    {
        int IRoot.Read() { return 71; }
        int IBranch.Read() { return 73; }
    }
    static int Main()
    {
        IBranch shared = new Shared();
        Check(shared.Read() == 67, "hiding-member-public-map");
        Check(((IRoot)shared).Read() == 67, "hidden-member-public-map");
        IBranch separate = new Separate();
        Check(((IRoot)separate).Read() == 71, "explicit-base-control");
        Check(separate.Read() == 73, "explicit-derived-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
