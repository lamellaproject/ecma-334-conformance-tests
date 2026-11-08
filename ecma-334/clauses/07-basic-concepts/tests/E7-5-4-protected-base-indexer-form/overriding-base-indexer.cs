/*
Rules: E7-5-4-protected-base-indexer-form
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return base[key] + 7;
Into: return base[key];
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
        protected virtual int this[int key] { get { return key * 5; } }
    }
    class Branch : Root
    {
        protected override int this[int key] { get { return base[key] + 7; } }
        public int Read(int key) { return this[key]; }
    }
    static int Main()
    {
        Check(new Branch().Read(11) == 62, "protected-override-base-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
