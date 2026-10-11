/*
Rules: E10-8-compatible; E10-8-argument-types; E10-8-instance; E10-8-result; E10-8-cast; E10-8-evaluate-instance; E10-8-allocate; E10-2-1-categories
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: source.Number=82;
Into: source.Number=83;
*/
using System;


class Receiver {public int Number;public long Read(int n){return Number+n;} public long Read(long n){return -1;}}
static class Trace {public static int Calls;public static Receiver Get(Receiver r){Calls++;return r;}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver source=new Receiver {Number=61}; Trace.Calls=0;
        Func<int,long> converted=(Func<int,long>)Trace.Get(source).Read;
        source.Number=82;
        Check(Trace.Calls==1 && ReferenceEquals(converted.Target,source) && converted(2)==84 && converted.GetInvocationList().Length==1, "E10-8-compatible-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
