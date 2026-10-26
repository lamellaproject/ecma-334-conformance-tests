/*
Rules: E10-3-7-ed2-valuetype-unboxing; E10-2-9-ed2-valuetype-boxing
Authority: ECMA-334 2nd ed 13.2.4
Version: ISO-1
Expected: run
Stdout: OK 3
Mutate: Parcel recovered = (Parcel)packed;
Into: Parcel recovered = new Parcel(0);
*/
using System;
struct Parcel
{
    public int Units;
    public Parcel(int units) { Units = units; }
}
enum Paint { Ochre = 36 }
class ValueTypeUnboxing
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
        System.ValueType packed = new Parcel(57);
        Parcel recovered = (Parcel)packed;
        Check(recovered.Units == 57, "valuetype-struct-unbox");
        System.ValueType scalar = (short)94;
        Check((short)scalar == 94, "valuetype-simple-unbox");
        System.ValueType choice = Paint.Ochre;
        Check((Paint)choice == Paint.Ochre, "valuetype-enum-unbox");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
