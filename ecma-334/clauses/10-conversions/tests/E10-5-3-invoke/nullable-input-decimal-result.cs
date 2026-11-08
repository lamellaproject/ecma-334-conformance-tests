/*
Rules: E10-5-3-invoke; E10-5-3-applicable; E15-10-4-conversion-nullable-source-underlying
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: item.Value.Mark + 5m
Into: item.Value.Mark + 6m
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
    static int calls;
    struct Measure
    {
        public int Mark;
        public Measure(int value) { Mark = value; }
        public static implicit operator decimal(Measure? item)
        {
            calls++;
            return item.HasValue ? item.Value.Mark + 5m : 17m;
        }
    }
    static int Main()
    {
        Measure? present = new Measure(42);
        decimal first = present;
        Check(first == 47m && calls == 1, "declared-nullable-decimal-present");
        Measure? missing = null;
        decimal second = missing;
        Check(second == 17m && calls == 2, "declared-nullable-decimal-null-invokes-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
