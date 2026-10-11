/*
Rules: E6-4-6-grammar-operator-or-punctuator-19; E6-4-6-grammar-operator-or-punctuator-29; E6-4-6-grammar-operator-or-punctuator-30
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: !condition
Into: condition
*/
using System;
class Program
{
    static int checks, failures, visits;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Visit() { visits++; return true; }
    static void Main()
    {
        bool condition = false;
        Check(!condition, "bang");
        bool both = condition && Visit();
        Check(!both && visits == 0, "double-ampersand");
        bool either = true || Visit();
        Check(either && visits == 0, "double-bar");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
