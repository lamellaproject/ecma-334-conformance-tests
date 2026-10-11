/*
Rules: E7-7-2-3-hiding-limited-to-new-scope
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: private new int Read()
Into: protected new int Read()
*/
using System;
class Root { public int Read() { return 127; } }
class Middle : Root { private new int Read() { return 131; } public int Own() { return Read(); } }
class Leaf : Middle { public int Probe() { return Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Check(value.Own() == 131, "private-new-member-hides-base-within-middle-scope");
        Check(value.Probe() == 127, "base-member-visible-outside-private-new-member-scope");
        Check(((Root)value).Read() == 127, "base-member-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
