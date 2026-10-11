/*
Rules: E7-6-indexer-signature-no-element-type; E7-6-duplicate-indexer-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: public string this[int index]
Into: public string this[long index]
*/
class Item
{
    public int this[int index] { get { return 73; } }
    public string this[int index] { get { return "cedar"; } }
}
class Program { static void Main() { } }
