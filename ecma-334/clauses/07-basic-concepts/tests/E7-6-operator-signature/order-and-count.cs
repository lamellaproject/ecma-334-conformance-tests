/*
Rules: E7-6-operator-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: operator +(int first, Item second)
Into: operator +(Item first, int second)
*/
using System;
class Item
{
    public static int operator +(Item value) { return 67; }
    public static int operator +(Item first, Item second) { return 71; }
    public static int operator +(Item first, int second) { return 73; }
    public static int operator +(int first, Item second) { return 79; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item();
        Check(+value == 67, "unary-operator-one-parameter");
        Check(value + value == 71, "binary-operator-two-item-parameters");
        Check(value + 5 == 73, "operator-parameter-types-item-int");
        Check(5 + value == 79, "operator-parameter-types-int-item");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
