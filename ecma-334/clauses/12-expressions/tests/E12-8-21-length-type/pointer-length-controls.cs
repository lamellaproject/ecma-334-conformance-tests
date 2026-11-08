/*
Rules: E12-8-21-length-type
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static implicit operator int(Count count)
Into: public static explicit operator int(Count count)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int conversions;
    struct Count
    {
        public static implicit operator int(Count count) { conversions++; return 3; }
    }
    static unsafe int Main()
    {
        short small = 3;
        long wide = 3L;
        Count amount = new Count();
        int* first = stackalloc int[small];
        int* second = stackalloc int[amount];
        int* third = stackalloc int[(int)wide];
        first[0] = 17;
        second[0] = 19;
        third[0] = 23;
        Check(first[0] == 17, "short-count");
        Check(second[0] == 19 && conversions == 1, "implicit-user-count");
        Check(third[0] == 23, "written-long-cast-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
