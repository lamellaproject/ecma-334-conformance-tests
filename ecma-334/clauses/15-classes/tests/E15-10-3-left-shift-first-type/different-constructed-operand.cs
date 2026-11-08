/*
Rules: E15-10-3-left-shift-first-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E15-10-3-left-shift-first-type/different-constructed-operand.cs.part
Mutate: Dial<int> item
Into: Dial<T> item
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
    class Dial<T>
    {
        public static int operator <<(Dial<int> item, int count) { return count + 3; }
    }
    static int Main()
    {
        Dial<string> item = new Dial<string>();
        Check(item != null, "containing-instantiation-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
