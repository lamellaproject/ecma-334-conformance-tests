/*
Rules: E15-11-5-nonabstract-default-constructor-public
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Gauge {
Into: public class Gauge { internal Gauge() { }
*/
using System;
public class Gauge { public int N = 13; }
class Program
{
    static int checks, failures;
    static T Create<T>() where T : new() { return new T(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Create<Gauge>().N == 13, "concrete-default-satisfies-public-new-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
