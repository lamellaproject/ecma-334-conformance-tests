/*
Rules: E18-6-5-indexer-parameters-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public int this[long index]
Into: public int this[int index]
Csc: CS0535
*/
interface IRead { int this[int index] { get; } }
class Reader : IRead { public int this[long index] { get { return 353; } } }
class Program { static void Main() { } }
