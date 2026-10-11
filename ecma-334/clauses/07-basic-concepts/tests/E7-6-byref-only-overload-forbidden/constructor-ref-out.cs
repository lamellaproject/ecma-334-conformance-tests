/*
Rules: E7-6-byref-only-overload-forbidden
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Item(out int value)
Into: Item(out long value)
*/
class Item
{
    public Item(ref int value) { }
    public Item(out int value) { value = 163; }
}
class Program { static void Main() { } }
