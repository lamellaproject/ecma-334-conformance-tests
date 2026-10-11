/*
Rules: E12-8-16-3-initializable-members; E12-8-16-3-brace-form; E12-8-16-3-trailing-comma-form; E12-8-16-3-member-list-form; E12-8-16-3-member-form; E12-8-16-3-identifier-target-form; E12-8-16-3-indexer-target-form; E12-8-16-3-expression-value-form; E12-8-16-3-expression-assignment; E12-8-16-2-constructor-before-initializer
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Field = Read(7, "F")
Into: Field = Read(17, "F")
*/
using System;
class Item
{
    public int Field, PropertyValue, IndexValue, Key;
    public Item() { Program.Trace += "C"; }
    public int Property { set { Program.Trace += "S"; PropertyValue = value; } }
    public int this[int key] { set { Program.Trace += "T"; Key = key; IndexValue = value; } }
}
class Program
{
    public static string Trace = "";
    static int Read(int value, string tag) { Trace += tag; return value; }
    static int Index() { Trace += "I"; return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item { Field = Read(7, "F"), Property = Read(9, "P"), [Index()] = Read(13, "V"), };
        Check(Trace == "CFPSIVT", "constructor-and-member-initializer-order");
        Check(value.Field == 7 && value.PropertyValue == 9, "field-and-property-assignment");
        Check(value.Key == 2 && value.IndexValue == 13, "indexer-arguments-and-assignment");
        Item empty = new Item { };
        Check(empty.Field == 0 && Trace == "CFPSIVTC", "empty-object-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
