/*
Rules: E12-20-3-1-no-range-out
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: reject
Mutate: Touch(out item)
Into: Touch(out storage)
Csc: CS1939
*/
delegate int Selector(int item);
class Source
{
    public int Select(Selector selector) { return selector(3); }
}
class Program
{
    static int storage;
    static int Touch(out int value) { value = 9; return value; }
    static void Main() { var result = from item in new Source() select Touch(out item); }
}
