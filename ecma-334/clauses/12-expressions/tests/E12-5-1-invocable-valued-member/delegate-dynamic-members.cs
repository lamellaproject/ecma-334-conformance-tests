/*
Rules: E12-5-1-invocable-valued-member
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int first = box.Call(4);
Into: int first = box.Call(5);
*/
using System;
public class Box
{
    public Func<int, int> Call;
    public dynamic DynamicCall { get { return Call; } }
}
class Program
{
    static int checks, failures;
    static int Double(int value) { return value * 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); box.Call = Double; int first = box.Call(4); int second = box.DynamicCall(6);
        Check(first == 8, "delegate-field-invocable");
        Check(second == 12, "dynamic-property-invocable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
