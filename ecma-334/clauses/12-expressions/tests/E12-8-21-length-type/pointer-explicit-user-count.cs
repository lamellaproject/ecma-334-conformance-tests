/*
Rules: E12-8-21-length-type
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-8-21-length-type/pointer-explicit-user-count.cs.part
Mutate: stackalloc int[count]
Into: stackalloc int[(int)count]
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
    struct Count
    {
        public static explicit operator int(Count count) { return 3; }
    }
    static unsafe int Main()
    {
        Count count = new Count();
        int* memory = stackalloc int[count];
        memory[0] = 17;
        Check(memory[0] == 17, "cast-count-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
