/*
Rules: E12-12-7-type-parameter-null; E12-12-7-type-parameter-value-equality; E12-12-7-type-parameter-value-inequality; E12-12-7-type-parameter-nullable; E12-12-7-type-parameter-reference
Authority: ECMA-334 7th ed 12.12.7
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: value == null
Into: value != null
*/
using System;
struct Token { }
class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Equal<T>(T value) { return value == null; }
    static bool Unequal<T>(T value) { return value != null; }
    static void Main()
    {
        Check(!Equal(0) && Unequal(0), "integer-value-never-null");
        Check(!Equal(new Token()) && Unequal(new Token()), "struct-value-never-null");
        Check(Equal<int?>(null) && !Unequal<int?>(null), "empty-nullable");
        Check(!Equal<int?>(0) && Unequal<int?>(0), "nullable-zero-has-value");
        Check(Equal<Item>(null) && !Unequal<Item>(null), "null-reference");
        Item item = new Item(); Check(!Equal(item) && Unequal(item), "nonnull-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
