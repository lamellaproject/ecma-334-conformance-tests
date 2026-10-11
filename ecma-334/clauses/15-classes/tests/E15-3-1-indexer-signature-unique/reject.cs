/*
Rules: E15-3-1-indexer-signature-unique
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public long this[int second]
Into: public long this[long second]
*/
class Meter
{
    public int this[int first] { get { return first; } }
    public long this[int second] { get { return second; } }
}
class Program { static void Main() { } }
