/*
Rules: P09-funcptr-parameter; P09-funcptr-return
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: delegate*<string,object> target=source;
Into: delegate*<string,object> target=default;
*/
using System;

static class Variance {public static string Label(object x)=>(string)x;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe {delegate*<object,string> source=&Variance.Label; delegate*<string,object> target=source; Check((string)target("cobalt")=="cobalt", "P09-funcptr-parameter-pilot-200001-check-01");}
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
