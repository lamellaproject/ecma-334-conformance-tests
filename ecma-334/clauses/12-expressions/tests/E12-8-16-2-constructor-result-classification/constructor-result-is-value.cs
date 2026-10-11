/*
Rules: E12-8-16-2-constructor-result-classification
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: Touch(ref new Item(7));
Into: Touch(ref value);
Csc: CS1510
*/
class Item { public Item(int number) { } }
class Program
{
    static void Touch(ref Item value) { }
    static void Main() { Item value = new Item(7); Touch(ref new Item(7)); }
}
