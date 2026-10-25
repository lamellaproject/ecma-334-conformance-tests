/*
Rules: E23-6-5-ed1-readonly-local-address-permitted
Authority: ECMA-334 1st ed 25.5.4
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: int* address = &number;
Into: int* address = &other;
*/
// 25.5.4, p. 330 (PDF p. 344), lines 17-20; 25.3, p. 326
// (PDF p. 340), lines 18-25 includes simple-name local variables.
// 15.8.4, p. 191 (PDF p. 205), lines 1-6 makes the iteration
// variable read-only but forbids assignment, increment/decrement,
// and ref/out passing, without forbidding this address/read.
// The later 23.6.5 adds a read-only-local address prohibition.
using System;
class Entry
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static unsafe int Main()
    {
        foreach (int number in new int[] { 71 })
        {
            int other = number + 1;
            int* address = &number;
            Check(other != number && *address == number, "iteration-address");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
