/*
Rules: E10-5-4-operator-ambiguous
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run-or-reject
Stdout: OK 2
Version-Witness: version-witnesses/E10-5-4-operator-ambiguous/primitive-nullable-result.cs.part
Mutate: int? result = source;
Into: int? result = 0;
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
        public static implicit operator int(Measure item)
        {
            calls++;
            return item.Mark + 6;
        }
    }
    static int Main()
    {
        Measure source = new Measure(41);
        int? result = source;
        Check(result.HasValue && result.Value == 47 && calls == 1, "primitive-result-wrapped-after-implicit");
        int control = (int)source;
        Check(control == 47 && calls == 2, "nonnullable-user-conversion-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
