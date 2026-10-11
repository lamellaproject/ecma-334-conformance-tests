/*
Rules: E12-20-3-1-no-range-assignment
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: reject
Mutate: select (item = 8)
Into: select (item + 8)
Csc: CS1947
*/
delegate int Selector(int item);
class Source
{
    public int Select(Selector selector) { return selector(3); }
}
class Program
{
    static void Main() { var result = from item in new Source() select (item = 8); }
}
