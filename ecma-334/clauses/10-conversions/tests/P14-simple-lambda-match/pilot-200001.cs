/*
Rules: P14-simple-lambda-match
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: run
Stdout: OK 1
Mutate: RefReader read=(ref x)=>x+43;
Into: RefReader read=default(RefReader);
*/
using System;

delegate int RefReader(ref int x);delegate int InReader(in int x);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        RefReader read=(ref x)=>x+43; InReader ro=(in x)=>x+47; int n=449;Check(read(ref n)==492 && ro(in n)==496, "P14-simple-lambda-match-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
