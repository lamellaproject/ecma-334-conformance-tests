/*
Rules: E7-6-conversion-signature-no-classification
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: explicit operator int(Item value)
Into: explicit operator long(Item value)
*/
class Item
{
    public static implicit operator int(Item value) { return 101; }
    public static explicit operator int(Item value) { return 103; }
}
class Program { static void Main() { } }
