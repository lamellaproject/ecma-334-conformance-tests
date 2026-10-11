/*
Rules: E15-3-10-4-reserve-item-name
Authority: ECMA-334 7th ed 15.3.10.4
Version: 7.3
Expected: reject
Mutate: public int Item;
Into: public int Other;
*/
class Gauge
{
    public int this[int index] { get { return 449; } }
    public int Item;
}
class Program { static void Main() { } }
