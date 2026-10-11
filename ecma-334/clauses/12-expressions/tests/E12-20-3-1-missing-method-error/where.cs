/*
Rules: E12-20-3-1-missing-method-error
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: reject
Mutate: from item in source where item > 0 select item
Into: from item in source select item
Csc: CS1936
*/
delegate int Selector(int item);
class Source
{
    public int Select(Selector selector) { return selector(5); }
}
class Program
{
    static void Main()
    {
        var source = new Source();
        var result = from item in source where item > 0 select item;
    }
}
