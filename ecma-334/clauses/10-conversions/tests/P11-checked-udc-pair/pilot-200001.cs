/*
Rules: P11-checked-udc-pair; P11-checked-udc-checked-selection; P11-checked-udc-unchecked-selection
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 3
Mutate: checked((int)input)==352
Into: unchecked((int)input)==352
*/
using System;


struct Measured {
    public int Code;
    public static explicit operator int(Measured x)=>x.Code+79;
    public static explicit operator checked int(Measured x)=>x.Code+83;
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Measured input=new Measured{Code=269};
        Check(checked((int)input)==352 && unchecked((int)input)==348, "P11-checked-udc-pair-pilot-200001-check-01");
        Measured? present=input; int? lifted=checked((int?)present); Check(lifted.Value==352, "P11-checked-udc-pair-pilot-200001-check-02");
        present=null; lifted=checked((int?)present); Check(!lifted.HasValue, "P11-checked-udc-pair-pilot-200001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
