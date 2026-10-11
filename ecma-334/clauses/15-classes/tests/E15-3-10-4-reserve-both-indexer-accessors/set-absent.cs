/*
Rules: E15-3-10-4-reserve-both-indexer-accessors; E15-3-10-4-reserve-indexer-set; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: reject
Mutate: public void set_Item(int index, int value)
Into: public void Write(int index, int value)
*/
class Gauge
{
    public int this[int index] { get { return 443; } }
    public void set_Item(int index, int value) { }
}
class Program { static void Main() { } }
