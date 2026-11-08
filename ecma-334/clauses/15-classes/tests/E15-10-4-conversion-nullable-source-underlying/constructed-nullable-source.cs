/*
Rules: E15-10-4-conversion-nullable-source-underlying
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Nullable<Rotor> item
Into: Rotor item
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
    struct Rotor
    {
        public int Mark;
        public Rotor(int value) { Mark = value; }
        public static implicit operator int(Nullable<Rotor> item)
        {
            return item.HasValue ? item.Value.Mark + 7 : 5;
        }
    }
    static int Main()
    {
        Nullable<Rotor> present = new Rotor(31);
        int first = present;
        Check(first == 38, "constructed-nullable-conversion-present");
        Nullable<Rotor> absent = null;
        int second = absent;
        Check(second == 5, "constructed-nullable-conversion-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
