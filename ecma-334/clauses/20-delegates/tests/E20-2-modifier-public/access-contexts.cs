/*
Rules: E20-2-modifier-public; E20-2-modifier-protected; E20-2-modifier-internal; E20-2-modifier-private; E20-2-accessibility-modifiers
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: protected delegate int ProtectedRead();
Into: private delegate int ProtectedRead();
*/
using System;
public delegate int PublicRead();
internal delegate int InternalRead();
class Root
{
    private delegate int PrivateRead();
    protected delegate int ProtectedRead();
    static int Read() { return 29; }
    public int PrivateValue() { PrivateRead reader = new Root.PrivateRead(Read); return reader(); }
}
class Branch : Root
{
    static int Read() { return 31; }
    public int ProtectedValue() { ProtectedRead reader = new Root.ProtectedRead(Read); return reader(); }
}
class Program
{
    static int checks, failures;
    static int Read() { return 37; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        PublicRead publicValue = new PublicRead(Read);
        InternalRead internalValue = new InternalRead(Read);
        Check(publicValue() == 37, "public-delegate");
        Check(internalValue() == 37, "internal-delegate");
        Check(new Root().PrivateValue() == 29, "private-delegate");
        Check(new Branch().ProtectedValue() == 31, "protected-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
