/*
Rules: E7-6-indexer-signature-no-params; E7-6-duplicate-indexer-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: this[params int[] values]
Into: this[params long[] values]
*/
class Item
{
    public int this[int[] values] { get { return 79; } }
    public int this[params int[] values] { get { return 83; } }
}
class Program { static void Main() { } }
