/*
Rules: E7-6-conversion-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: implicit operator int(Item value)
Into: implicit operator long(Item value)
*/
using System;
class Item
{
    public int Value;
    public static implicit operator int(Item value) { return value.Value; }
    public static implicit operator long(Item value) { return value.Value + 1; }
    public static implicit operator Item(int value) { return new Item { Value = value + 2 }; }
    public static implicit operator Item(long value) { return new Item { Value = (int)value + 3 }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item { Value = 97 };
        int first = value;
        long second = value;
        Item third = 5;
        Item fourth = 5L;
        Check(first == 97, "first-target-type");
        Check(second == 98, "second-target-type-with-same-source");
        Check(third.Value == 7, "first-source-type");
        Check(fourth.Value == 8, "second-source-type-with-same-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
