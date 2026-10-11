/*
Rules: E10-3-7-null-failure
Authority: ECMA-334 7th ed 10.3.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (int)missing
Into: (int)(object)61
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object missing = null;
        try
        {
            int result = (int)missing;
            Check(false, "null-unbox/required-exception");
        }
        catch (NullReferenceException) { Check(true, "null-unbox/required-exception"); }
        catch (Exception error)
        {
            Check(false, "null-unbox/exception-type");
            Console.WriteLine("EXCEPTION " + error.GetType().FullName);
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
