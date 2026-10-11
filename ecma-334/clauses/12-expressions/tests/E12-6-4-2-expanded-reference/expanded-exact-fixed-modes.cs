/*
Rules: E12-6-4-2-expanded-reference
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Read(ref first, out result, in input, 3, 5)
Into: Read(ref other, out result, in input, 3, 5)
*/
using System;
class Program
{
    static int checks, failures;
    static int Read(ref int first, out long result, in short input, params int[] tail)
    {
        first += input;
        result = tail[0] + tail[1];
        return tail.Length;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = 7;
        long other = 7, result;
        short input = 2;
        int count = Read(ref first, out result, in input, 3, 5);
        Check(first == 9, "expanded-call-ref-parameter-retains-exact-storage-type");
        Check(result == 8L, "expanded-call-out-parameter-retains-exact-storage-type");
        Check(count == 2 && input == 2, "expanded-call-explicit-input-retains-exact-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
