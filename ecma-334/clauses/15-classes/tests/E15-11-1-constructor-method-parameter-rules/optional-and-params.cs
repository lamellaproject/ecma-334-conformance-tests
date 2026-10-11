/*
Rules: E15-11-1-constructor-method-parameter-rules
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int seed = 3, params int[] rest
Into: int seed = 3, int[] rest = null
*/
using System;
class Gauge
{
    public int N;
    public Gauge(int seed = 3, params int[] rest) { N = seed; for (int i = 0; i < rest.Length; i++) N += rest[i]; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().N == 3, "constructor-optional-and-empty-params");
        Check(new Gauge(13, 2, 4).N == 19, "constructor-expanded-params");
        Check(new Gauge(rest: new int[] { 5 }).N == 8, "constructor-named-params-and-optional");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
