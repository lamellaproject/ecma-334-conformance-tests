/*
Rules: E18-6-5-indexer-type-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public long this[int index]
Into: public int this[int index]
Csc: CS0738
*/
interface IRead { int this[int index] { get; } }
class Reader : IRead { public long this[int index] { get { return 349; } } }
class Program { static void Main() { } }
