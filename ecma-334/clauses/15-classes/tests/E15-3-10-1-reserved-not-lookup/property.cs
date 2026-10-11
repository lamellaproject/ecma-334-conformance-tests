/*
Rules: E15-3-10-1-reserved-not-lookup
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public int get_Code = 457;
Into: public int Other = 457;
*/
using System;
class Root { public int get_Code = 457; public int set_Code = 461; }
class Leaf : Root { public int Code { get { return 463; } set { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.get_Code == 457, "reserved-property-get-name-does-not-hide-field-lookup");
        Check(leaf.set_Code == 461, "reserved-property-set-name-does-not-hide-field-lookup");
        Check(leaf.Code == 463, "declared-property-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
