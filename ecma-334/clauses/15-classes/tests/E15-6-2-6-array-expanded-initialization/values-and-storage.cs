/*
Rules: E15-6-2-6-array-expanded-initialization; E15-6-2-6-array-parameter-classification; E15-6-2-6-array-expanded-arguments; E15-6-2-6-array-expanded-allocation; E15-6-2-6-array-expanded-length; E15-6-2-6-array-expanded-pass; E15-6-2-6-array-overload-expanded-form
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: static long[] Gather(params long[] values)
Into: static long[] Gather(long[] values)
*/
using System;
class Program
{
    static int calls, trace;
    static int Next(int value) { calls++; trace = trace * 10 + value; return value; }
    static long[] Gather(params long[] values) { return values; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long[] first = Gather(Next(2), Next(3), Next(5));
        Check(calls == 3 && trace == 235, "expanded-expressions-evaluated-once-in-order");
        Check(first.Length == 3, "expanded-array-length-matches-argument-count");
        Check(first[0] == 2 && first[1] == 3 && first[2] == 5, "converted-elements-preserve-argument-order");
        long[] second = Gather(2, 3, 5);
        Check(first != second, "nonempty-expanded-calls-provide-distinct-arrays");
        first[0] = 17;
        Check(second[0] == 2, "fresh-expanded-storage-is-independent");
        Check(Gather().Length == 0, "zero-expanded-arguments-provide-empty-array");
        byte value = 7;
        long[] single = Gather(value);
        Check(single.Length == 1 && single[0] == 7, "single-expanded-argument-implicitly-converted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
