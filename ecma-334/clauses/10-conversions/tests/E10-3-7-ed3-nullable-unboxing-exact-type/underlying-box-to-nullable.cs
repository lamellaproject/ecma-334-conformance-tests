/*
Rules: E10-3-7-ed3-nullable-unboxing-exact-type
Authority: ECMA-334 3rd ed 11.3.2
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E10-3-7-ed3-nullable-unboxing-exact-type/underlying-box-to-nullable.cs.part
Mutate: int? result = (int?)boxed;
Into: int? result = new int?((int)boxed);
*/
// ECMA-334 3rd ed 11.3.2, p. 115 (PDF p. 135).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        object boxed = 31;
        bool threw = false;
        try
        {
            int? result = (int?)boxed;
            if (result.HasValue) threw = false;
        }
        catch (InvalidCastException) { threw = true; }
        Check(threw, "nullable-exact-unboxing-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
