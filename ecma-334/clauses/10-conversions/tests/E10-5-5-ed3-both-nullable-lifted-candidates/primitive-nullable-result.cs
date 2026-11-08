/*
Rules: E10-5-5-ed3-both-nullable-lifted-candidates
Authority: ECMA-334 3rd ed 13.4.4
Version: ISO-2
Expected: run
Stdout: OK 2
Mutate: return item.Mark + 6;
Into: return item.Mark + 7;
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
        public static explicit operator int(Measure item)
        {
            calls++;
            return item.Mark + 6;
        }
    }
    static int Main()
    {
        Measure source = new Measure(41);
        int? result = (int?)source;
        Check(result.HasValue && result.Value == 47 && calls == 1, "primitive-result-wrapped-after-explicit");
        int control = (int)source;
        Check(control == 47 && calls == 2, "nonnullable-user-conversion-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
