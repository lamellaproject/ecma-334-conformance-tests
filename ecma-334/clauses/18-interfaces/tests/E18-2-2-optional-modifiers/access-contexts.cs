/*
Rules: E18-2-2-optional-modifiers; E18-2-2-modifier-public; E18-2-2-modifier-protected; E18-2-2-modifier-internal; E18-2-2-modifier-private; E18-2-2-accessibility-modifiers
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: protected interface IProtected
Into: private interface IProtected
*/
using System;
public interface IPublic { }
internal interface IInternal { }
class PublicItem : IPublic { }
class InternalItem : IInternal { }
class Vault
{
    private interface IPrivate { }
    private class PrivateItem : IPrivate { }
    protected interface IProtected { }
    public bool PrivateWorks() { return new PrivateItem() is IPrivate; }
}
class OpenVault : Vault
{
    class ProtectedItem : IProtected { }
    public bool ProtectedWorks() { return new ProtectedItem() is IProtected; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new PublicItem() is IPublic, "public");
        Check(new InternalItem() is IInternal, "internal");
        Check(new Vault().PrivateWorks(), "private");
        Check(new OpenVault().ProtectedWorks(), "protected-in-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
