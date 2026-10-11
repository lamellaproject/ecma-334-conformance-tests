/*
Rules: E10-7-1-typed
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (ref int x)=>{x+=2;}
Into: (ref int x)=>{x+=3;}
*/
using System;

delegate void Change(ref int x); delegate void Make(out int x); delegate int Read(in int x);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Change refValue=(ref int x)=>{x+=2;};
        Make outValue=delegate(out int x){x=61;};
        Read inValue=(in int x)=>x+3;
        int n=0; outValue(out n); refValue(ref n);
        Check(n==63 && inValue(in n)==66, "E10-7-1-typed-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
