/*
Rules: E10-8-extension
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<int,int> extended=missing.Measure;
Into: Func<int,int> extended=(int n)=>0;
*/
using System;


static class Extensions {public static int Measure(this string text,int extra){return (text==null?61:text.Length)+extra;}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string missing=null; Func<int,int> extended=missing.Measure;
        Check(extended(2)==63, "E10-8-extension-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
