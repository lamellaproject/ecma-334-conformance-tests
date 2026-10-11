/*
Rules: E15-3-10-4-reserve-indexer-get; E15-3-10-1-reserve-accessor-signatures; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: reject
Mutate: public int get_Item(int index)
Into: public int Read(int index)
*/
class Gauge
{
    public int this[int index] { get { return 431; } }
    public int get_Item(int index) { return 433; }
}
class Program { static void Main() { } }
