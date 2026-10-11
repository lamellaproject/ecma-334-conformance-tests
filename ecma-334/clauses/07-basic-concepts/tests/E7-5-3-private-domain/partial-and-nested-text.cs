/*
Rules: E7-5-3-private-domain; E7-5-3-type-text-definition; E7-5-3-accessibility-domain-definition; E7-5-2-private-modifier; E7-5-2-class-member-access-kinds
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: private class Inner { public static int Read() { return secret; } }
Into: } class Inner { public static int Read() { return Vault.secret; } } partial class Vault {
*/
using System;
#if FIRST_UNIT
partial class Vault
{
    private const int secret = 71;
    private class Inner { public static int Read() { return secret; } }
}
#elif SECOND_UNIT
partial class Vault
{
    public static int Direct() { return secret; }
    public static int Nested() { return Inner.Read(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Vault.Direct() == 71, "private-member-from-other-declaration-part");
        Check(Vault.Nested() == 71, "private-member-from-nested-type-text");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
