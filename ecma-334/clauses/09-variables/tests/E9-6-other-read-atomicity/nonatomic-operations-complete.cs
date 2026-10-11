/*
Rules: E9-6-other-read-atomicity; E9-6-other-write-atomicity
Authority: ECMA-334 7th ed 9.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long readLong = wide;
Into: long readLong = Fail();
*/
using System;
using System.Threading;
struct Pair { public int A, B; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static long wide;
    static ulong unsigned;
    static double floating;
    static decimal precise;
    static Pair pair;
    static long Fail() { throw new Exception(); }
    static void Write()
    {
        for (int i = 0; i < 20000; i++)
        {
            wide = i;
            unsigned = (ulong)i;
            floating = i;
            precise = i;
            pair = new Pair { A = i, B = -i };
        }
    }
    static void Main()
    {
        Thread writer = new Thread(Write);
        writer.Start();
        int completed = 0;
        for (int i = 0; i < 20000; i++)
        {
            // These types permit tearing; every read result is allowed and only completion is checked.
            long readLong = wide;
            ulong readUnsigned = unsigned;
            double readFloating = floating;
            decimal readPrecise = precise;
            Pair readPair = pair;
            completed++;
        }
        writer.Join();
        Check(completed == 20000, "nonatomic-reads-and-writes-complete-without-a-value-oracle");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
