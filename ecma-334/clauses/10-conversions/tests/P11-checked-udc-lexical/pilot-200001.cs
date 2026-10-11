/*
Rules: P11-checked-udc-lexical
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 1
Mutate: Body input=new Body{Code=int.MaxValue};
Into: Body input=default(Body);
*/
using System;

struct Body {public int Code;public static explicit operator int(Body x)=>x.Code;public static explicit operator checked int(Body x)=>x.Code+1;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Body input=new Body{Code=int.MaxValue}; Check(checked((int)input)==int.MinValue, "P11-checked-udc-lexical-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
