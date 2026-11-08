/*
Rules: E12-6-4-3-better-conversions; E12-6-4-7-target-one-way-conversion; E10-2-9-nullable
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Select(first) == 3
Into: Select(number) == 3
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
    struct Plain { }
    struct Ordered : IComparable
    {
        public int CompareTo(object other) { return 0; }
    }
    static int Select(object value) { return 3; }
    static int Select(IComparable value) { return 7; }
    static int Main()
    {
        int? number = 43;
        Check(Select(number) == 7, "underlying-int-interface-overload");
        Plain? first = new Plain();
        Check(Select(first) == 3, "plain-nullable-object-overload");
        Nullable<Plain> second = new Plain();
        Check(Select(second) == 3, "constructed-nullable-object-overload");
        Ordered? implemented = new Ordered();
        Check(Select(implemented) == 7, "underlying-user-interface-overload");
        int? missing = null;
        Check(Select(missing) == 7, "nullable-null-static-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
