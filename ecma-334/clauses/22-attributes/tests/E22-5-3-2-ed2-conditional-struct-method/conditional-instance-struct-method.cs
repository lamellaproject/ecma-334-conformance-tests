/*
Rules: E22-5-3-2-ed2-conditional-struct-method
Authority: ECMA-334 2nd ed 24.4.2
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: Conditional("DELIVERY")
Into: Conditional("OMITTED_DELIVERY")
*/
#define DELIVERY
using System;
class DeliveryMeter { public static int Count; }
struct Courier
{
    [System.Diagnostics.Conditional("DELIVERY")]
    public void Dispatch() { DeliveryMeter.Count++; }
}
class ConditionalStruct
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static int Main()
    {
        Courier worker = new Courier();
        worker.Dispatch();
        Check(DeliveryMeter.Count == 1, "conditional-struct-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
