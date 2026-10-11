/*
Rules: E14-7-class-nested-public; E14-7-class-nested-protected-internal; E14-7-class-nested-protected; E14-7-class-nested-private-protected; E14-7-class-nested-internal; E14-7-class-nested-private
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class PublicPart
Into: private class PublicPart
*/
using System;
class Owner
{
    public class PublicPart { public const int Code = 29; }
    protected internal class SharedPart { public const int Code = 31; }
    protected class FamilyPart { public const int Code = 37; }
    private protected class ClosePart { public const int Code = 41; }
    internal class InternalPart { public const int Code = 43; }
    private class PrivatePart { public const int Code = 47; }
    public static int Read() { return SharedPart.Code + FamilyPart.Code + ClosePart.Code + InternalPart.Code + PrivatePart.Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Owner.PublicPart.Code == 29, "nested-public-access");
        Check(Owner.Read() == 199, "remaining-nested-access-forms");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
