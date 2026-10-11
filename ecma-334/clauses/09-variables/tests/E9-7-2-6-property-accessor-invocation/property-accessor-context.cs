/*
Rules: E9-7-2-6-property-accessor-invocation
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return ref holder.Location;
Into: return ref backup;
*/
using System;
class Holder
{
    int cell = 75;
    public ref int Location { get { return ref cell; } }
}
class Program
{
    static int checks, failures, backup = 7;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Select()
    {
        Holder holder = new Holder();
        return ref holder.Location;
    }
    static void Main()
    {
        ref int alias = ref Select();
        Check(alias == 75, "property-getter-invocation-has-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
