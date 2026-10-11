/*
Rules: E7-6-operator-signature-no-result; E7-6-duplicate-operator-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: operator +(Item left, Item other)
Into: operator +(Item left, int other)
*/
class Item
{
    public static Item operator +(Item left, Item right) { return left; }
    public static int operator +(Item left, Item other) { return 89; }
}
class Program { static void Main() { } }
