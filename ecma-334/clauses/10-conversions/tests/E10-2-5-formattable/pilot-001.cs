/*
Rules: E10-2-5-formattable; E10-2-5-deferred; E12-8-3-formattable; E12-8-3-factory; E12-8-3-format; E12-8-3-argument-order; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: $"item:{Trace.Get(1),4:X2}|{Trace.Get(2),-5}"
Into: $"changed:{Trace.Get(1),4:X2}|{Trace.Get(2),-5}"
*/
using System;


class Probe:IFormattable {public int Number;public static int Formats;
    public string ToString(string format,IFormatProvider provider){Formats++;return Number.ToString(format,provider);}
    public override string ToString(){return ToString(null,null);}
}
static class Trace {public static string Log=""; public static Probe Get(int n){Log+=n;return new Probe {Number=n};}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Trace.Log=""; Probe.Formats=0;
        FormattableString stored=$"item:{Trace.Get(1),4:X2}|{Trace.Get(2),-5}";
        IFormattable asInterface=$"other:{Trace.Get(3)}";
        Check(Trace.Log=="123" && Probe.Formats==0 && stored.Format=="item:{0,4:X2}|{1,-5}", "E10-2-5-formattable-pilot-001-check-01");
        Check(stored.ArgumentCount==2 && ((Probe)stored.GetArgument(0)).Number==1 && ((Probe)stored.GetArgument(1)).Number==2, "E10-2-5-formattable-pilot-001-check-02");
        string rendered=stored.ToString(null);
        Check(rendered=="item:  01|2    " && Probe.Formats==2 && asInterface.ToString(null,null)=="other:3", "E10-2-5-formattable-pilot-001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
