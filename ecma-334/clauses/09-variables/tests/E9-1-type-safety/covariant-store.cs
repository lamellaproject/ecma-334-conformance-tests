/*
Rules: E9-1-type-safety
Authority: ECMA-334 7th ed 9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: slots[0] = new object();
Into: slots[0] = "allowed";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] strings = new string[] { "kept" };
        object[] slots = strings;
        bool rejected = false;
        try { slots[0] = new object(); }
        catch (ArrayTypeMismatchException) { rejected = true; }
        catch (Exception) { }
        Check(rejected, "incompatible-store-throws");
        Check(strings[0] == "kept", "storage-retains-appropriate-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
