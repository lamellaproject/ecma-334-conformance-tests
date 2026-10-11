/*
Rules: E14-7-struct-nested-public; E14-7-struct-nested-internal; E14-7-struct-nested-private
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class PublicPart
Into: protected class PublicPart
*/
using System;
struct Owner
{
    public class PublicPart { public const int Code = 29; }
    internal class InternalPart { public const int Code = 31; }
    private class PrivatePart { public const int Code = 37; }
    public static int Read() { return InternalPart.Code + PrivatePart.Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Owner.PublicPart.Code == 29, "struct-public-nested");
        Check(Owner.Read() == 68, "struct-internal-and-private");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
