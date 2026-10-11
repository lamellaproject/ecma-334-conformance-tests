/*
Rules: E12-20-3-1-argument-type-error
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: reject
Mutate: select item + 6
Into: select "mark"
Csc: CS0029
*/
delegate string Selector(int item);
class Source
{
    public string Select(Selector selector) { return selector(2); }
}
class Program
{
    static void Main() { var result = from item in new Source() select item + 6; }
}
