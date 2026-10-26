/*
Rules: E10-2-9-ed2-valuetype-boxing
Authority: ECMA-334 2nd ed 13.1.5
Version: ISO-1
Expected: run
Stdout: OK 3
Mutate: System.ValueType packed = original;
Into: System.ValueType packed = new Parcel(0);
*/
using System;
struct Parcel
{
    public int Units;
    public Parcel(int units) { Units = units; }
}
enum Paint { Ochre = 36 }
class ValueTypeBoxing
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
        Parcel original = new Parcel(43);
        System.ValueType packed = original;
        original.Units = 9;
        Check(((Parcel)(object)packed).Units == 43, "valuetype-struct-copy");
        System.ValueType scalar = (short)81;
        Check((short)(object)scalar == 81, "valuetype-simple-box");
        System.ValueType choice = Paint.Ochre;
        Check((Paint)(object)choice == Paint.Ochre, "valuetype-enum-box");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
