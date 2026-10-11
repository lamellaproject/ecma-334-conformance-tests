/*
Rules: E12-20-2-query-keyword-binding
Authority: ECMA-334 7th ed 12.20.2
Version: 7.3
Expected: reject
Mutate: select item + select
Into: select item + @select
Csc: CS1525
*/
delegate int Selector(int item);
class Source
{
    public int Select(Selector selector) { return selector(2); }
}
class Program
{
    static void Main()
    {
        int select = 5;
        int result = from item in new Source() select item + select;
    }
}
