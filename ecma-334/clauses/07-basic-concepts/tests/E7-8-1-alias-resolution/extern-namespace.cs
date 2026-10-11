/*
Rules: E7-8-1-alias-resolution; E7-8-1-name-form-alias
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"alias":"Vendor","library":"Fixture"}]}}
Mutate: Vendor.Fruit dotted = new Vendor.Fruit();
Into: Fruit dotted = new Fruit();
*/
#if LIBRARY
public class Fruit { public int Value = 101; }
#else
extern alias Vendor;
using System;
class Fruit { public int Value = 99; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Vendor.Fruit dotted = new Vendor.Fruit();
        Vendor::Fruit qualified = new Vendor::Fruit();
        Check(dotted.Value == 101, "extern-namespace-alias-resolves-at-import-stage");
        Check(qualified.Value == 101, "extern-qualified-alias-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
