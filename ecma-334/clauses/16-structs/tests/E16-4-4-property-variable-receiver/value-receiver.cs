/*
Rules: E16-4-4-property-variable-receiver
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: reject
Mutate: Make().Value = 7;
Into: Entry item = Make(); item.Value = 7;
*/
struct Entry { public int Value { get; set; } }
class Program
{
    static Entry Make() { return new Entry(); }
    static void Main() { Make().Value = 7; }
}
