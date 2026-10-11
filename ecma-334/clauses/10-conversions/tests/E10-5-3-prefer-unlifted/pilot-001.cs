/*
Rules: E10-5-3-prefer-unlifted; E10-5-4-operator; E10-5-2-underlying
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Second? result=source;
Into: Second? result=default(Second?);
*/
using System;


static class Trace {public static string Log="";}
struct First {public int Number;
    public static implicit operator Second(First x){Trace.Log+="ordinary";return new Second {Number=x.Number};}
    public static implicit operator Second?(First? x){Trace.Log+="nullable";return new Second {Number=x.Value.Number+1};}
}
struct Second {public int Number;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        First? source=new First {Number=61}; Second? result=source;
        Check(result.Value.Number==62 && Trace.Log=="nullable", "E10-5-3-prefer-unlifted-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
