/*
Rules: P12-collection-exception; P12-collection-order; P12-collection-array
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: [Step(1), Step(2), Step(3)]
Into: [Step(1), Step(3)]
*/
using System;
class Burst : Exception { }
class Program
{
    static int checks, failures, trace;
    static int Step(int mark) { trace = trace * 10 + mark; if (mark == 2) throw new Burst(); return mark; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int[] previous = new int[] { 29 };
        int[] values = previous;
        bool caught = false, completed = false;
        try { values = [Step(1), Step(2), Step(3)]; completed = true; }
        catch (Burst) { caught = true; }
        catch (Exception) { }
        Check(caught, "element-exception-type");
        Check(trace == 12, "later-element-not-evaluated");
        Check(!completed, "construction-stopped");
        Check(object.ReferenceEquals(values, previous), "failed-construction-not-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
