/*
Rules: E7-3-embedded-statement-space; E7-3-disjoint-local-name-reuse
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: if (true) Sink(Produce(23, out int value), value);
Into: Sink(Produce(23, out int value), value);
*/
using System;
class Program
{
    static int sum;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Produce(int number, out int result) { result = number; return number; }
    static void Sink(int first, int second) { sum += first + second; }
    static void Main()
    {
        if (true) Sink(Produce(17, out int value), value);
        if (true) Sink(Produce(23, out int value), value);
        Check(sum == 80, "embedded-statements-have-separate-spaces");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
