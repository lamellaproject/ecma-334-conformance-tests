/*
Rules: E12-8-14-base-indexer-required
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: base["fir"]
Into: this["fir"]
*/
class Root { public int this[int index] { get { return index; } } }
class Leaf : Root
{
    public int this[string index] { get { return 3; } }
    public int Read() { return base["fir"]; }
}
class Program { static void Main() { new Leaf().Read(); } }
