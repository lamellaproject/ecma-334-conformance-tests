/*
Rules: E16-4-4-indexer-variable-receiver
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: reject
Mutate: Make()[0] = 7;
Into: Entry item = Make(); item[0] = 7;
*/
struct Entry { public int this[int index] { get { return 0; } set { } } }
class Program
{
    static Entry Make() { return new Entry(); }
    static void Main() { Make()[0] = 7; }
}
