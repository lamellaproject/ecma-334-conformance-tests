/*
Rules: E15-10-3-binary-signature-parameter-types
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: operator *(Gauge x, long n)
Into: operator *(Gauge x, int n)
*/
using System;
class Gauge
{
    public static int operator *(Gauge x, int n) { return 13; }
    public static int operator *(Gauge x, long n) { return 19; }
    public static int operator *(int n, Gauge x) { return 23; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item * 3 == 13, "binary-int-parameter-signature");
        Check(item * 3L == 19, "binary-long-parameter-signature");
        Check(3 * item == 23, "binary-ordered-parameter-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
