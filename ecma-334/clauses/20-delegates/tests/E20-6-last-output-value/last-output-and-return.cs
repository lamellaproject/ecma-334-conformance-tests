/*
Rules: E20-6-last-output-value; E20-6-last-return-value
Authority: ECMA-334 7th ed 20.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Read composed = first + second;
Into: Read composed = second + first;
*/
using System;
delegate int Read(out int value);
class Program
{
    static int checks, failures;
    static int stored;
    static int A(out int value)
    {
        value = 19;
        Check(stored == 19, "first-output-live-variable");
        return 23;
    }
    static int B(out int value)
    {
        value = 29;
        Check(stored == 29, "second-output-live-variable");
        return 31;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Read first = A, second = B;
        Read composed = first + second;
        int result = composed(out stored);
        Check(stored == 29, "last-target-output-value");
        Check(result == 31, "last-target-result-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
