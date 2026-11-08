/*
Rules: E12-4-6-type-parameter-base
Authority: ECMA-334 7th ed 12.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return -source;
Into: return 0;
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
    class Root
    {
        public int Number;
        public Root(int number) { Number = number; }
        public static int operator -(Root source) { return source.Number + 6; }
    }
    class Leaf : Root { public Leaf(int number) : base(number) { } }
    static int Negate<T>(T source) where T : Root { return -source; }
    static int Main()
    {
        Check(Negate(new Leaf(23)) == 29, "unary-effective-base-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
