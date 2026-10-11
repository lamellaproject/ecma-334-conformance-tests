/*
Rules: E9-5-variable-reference-classification; E9-5-variable-reference-fetch; E9-5-variable-reference-store; E9-5-variable-reference-form
Authority: ECMA-334 7th ed 9.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Exchange(ref cells[index], 47)
Into: Exchange(ref cells[0], 47)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Exchange(ref int location, int replacement)
    {
        int previous = location;
        location = replacement;
        return previous;
    }
    static void Main()
    {
        int[] cells = { 13, 17 };
        int index = 1;
        int old = Exchange(ref cells[index], 47);
        Check(old == 17, "fetch-current-value-of-designated-storage");
        Check(cells[1] == 47, "store-new-value-in-designated-storage");
        Check(cells[0] == 13, "other-location-unaffected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
