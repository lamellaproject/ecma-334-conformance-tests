/*
Rules: E15-10-3-left-shift-first-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Nullable<Rotor> item
Into: Nullable<int> item
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
        public static int operator <<(Nullable<Rotor> item, int count)
        {
            return item.HasValue ? count + 13 : 11;
        }
    }
    static int Main()
    {
        Rotor? present = new Rotor();
        Check((present << 4) == 17, "constructed-nullable-first-operand");
        Rotor? absent = null;
        Check((absent << 4) == 11, "declared-nullable-operator-sees-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
