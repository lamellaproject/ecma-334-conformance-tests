/*
Rules: E7-6-constructor-signature-no-params; E7-6-duplicate-constructor-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Item(params int[] values)
Into: Item(params long[] values)
*/
class Item
{
    public Item(int[] values) { }
    public Item(params int[] values) { }
}
class Program { static void Main() { } }
