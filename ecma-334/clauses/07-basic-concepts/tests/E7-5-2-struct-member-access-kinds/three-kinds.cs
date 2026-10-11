/*
Rules: E7-5-2-struct-member-access-kinds
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: internal int AssemblyRead()
Into: private int AssemblyRead()
*/
using System;
struct Item
{
    private int Secret() { return 139; }
    internal int AssemblyRead() { return Secret(); }
    public int PublicRead() { return Secret() + 1; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item();
        Check(value.AssemblyRead() == 139, "struct-internal-member-in-same-program");
        Check(value.PublicRead() == 140, "struct-public-member");
        Check(value.AssemblyRead() + 1 == value.PublicRead(), "struct-private-member-in-containing-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
