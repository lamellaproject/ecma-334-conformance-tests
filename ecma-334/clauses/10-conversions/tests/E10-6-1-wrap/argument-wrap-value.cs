/*
Rules: E10-6-1-wrap; E10-6-1-classification
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Consume(input)
Into: Consume((int?)null)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Consume(int? value) { return value.HasValue ? value.Value : 0; }
    static int Consume(string value) { return -1; }
    static int Read() { return 7; }
    static void Main()
    {
        int input = Read();
        int result = Consume(input);
        Check(result == 7, "nullable-wrap/argument-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
