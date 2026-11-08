/*
Rules: E12-4-8-unary-lifted-value; E12-4-8-unary-lifting; E12-4-8-unary-lifted-null
Authority: ECMA-334 7th ed 12.4.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: filled++
Into: filled--
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
    struct Rotor
    {
        public int Mark;
        public Rotor(int value) { Mark = value; }
        public static Rotor operator ++(Rotor item) { calls++; return new Rotor(item.Mark + 3); }
    }
    static int Main()
    {
        Rotor? filled = new Rotor(19);
        Rotor? before = filled++;
        Check(before.Value.Mark == 19 && filled.Value.Mark == 22 && calls == 1, "lifted-postfix-user-increment");
        Rotor? after = ++filled;
        Check(after.Value.Mark == 25 && filled.Value.Mark == 25 && calls == 2, "lifted-prefix-user-increment");
        Rotor? missing = null;
        Rotor? absent = ++missing;
        Check(!missing.HasValue && !absent.HasValue && calls == 2, "lifted-increment-null-skips-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
