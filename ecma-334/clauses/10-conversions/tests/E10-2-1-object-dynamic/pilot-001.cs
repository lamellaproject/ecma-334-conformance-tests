/*
Rules: E10-2-1-object-dynamic; E10-2-2-object-dynamic; E10-2-2-generic; E10-2-2-tuple; E10-2-8-identity-target
Authority: ECMA-334 7th ed 10.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object restored=dynamicToken;
Into: object restored=new object();
*/
using System;
using System.Collections.Generic;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object token=new object(); dynamic dynamicToken=token; object restored=dynamicToken;
        List<dynamic> first=new List<dynamic>(); List<object> second=first;
        first.Add(token);
        (object,int) left=(token,61); (dynamic,int) right=left; (object,int) again=right;
        Check(ReferenceEquals(restored,token) && ReferenceEquals(first,second) && ReferenceEquals(second[0],token), "E10-2-1-object-dynamic-pilot-001-check-01");
        Check(ReferenceEquals(again.Item1,token) && again.Item2==61, "E10-2-1-object-dynamic-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
