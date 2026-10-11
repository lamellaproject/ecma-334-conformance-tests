/*
Rules: P15-union15-shadow
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 1
Mutate: Preferred explicit_=(Preferred)773;
Into: Preferred explicit_=default(Preferred);
*/
using System;

[System.Runtime.CompilerServices.Union]struct Preferred{public object Value{get;}public Preferred(int x){Value=x;}public static implicit operator Preferred(int x)=>new Preferred(x+1001);}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Preferred implicit_=769;Preferred explicit_=(Preferred)773;Check((int)implicit_.Value==1770 && (int)explicit_.Value==1774, "P15-union15-shadow-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
