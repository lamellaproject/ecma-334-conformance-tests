/*
Rules: P08-static-local-nested-capture
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: static Func<int> MakeLambda(int seed) { return () => seed += 2; }
Into: static Func<int> MakeLambda(int seed) { return () => seed; }
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
    static int Main()
    {
        static Func<int> Make(int seed)
        {
            int state = seed;
            int Next() { return ++state; }
            return Next;
        }
        static Func<int> MakeLambda(int seed) { return () => seed += 2; }
        Func<int> first = Make(40);
        Func<int> second = MakeLambda(70);
        Check(first() == 41, "static-local-nested-local-first-state");
        Check(first() == 42, "static-local-nested-local-shared-state");
        Check(second() == 72, "static-local-nested-lambda-first-state");
        Check(second() == 74, "static-local-nested-lambda-shared-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
