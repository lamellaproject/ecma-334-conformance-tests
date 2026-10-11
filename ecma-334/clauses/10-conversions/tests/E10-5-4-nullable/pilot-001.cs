/*
Rules: E10-5-4-nullable; E10-5-4-lifted; E10-6-2-exists; E10-6-2-nonnull; E10-6-2-null; E10-6-2-classification
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Second? result=filled, absent=empty;
Into: Second? result=empty, absent=empty;
*/
using System;


struct First {public int Number;public static int Calls;public static implicit operator Second(First x){Calls++;return new Second {Number=x.Number+1};}}
struct Second {public int Number;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        First? filled=new First {Number=61}, empty=null;
        Second? result=filled, absent=empty;
        Check(result.Value.Number==62 && !absent.HasValue && First.Calls==1, "E10-5-4-nullable-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
