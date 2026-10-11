/*
Rules: E18-6-5-property-type-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public long Value
Into: public int Value
Csc: CS0738
*/
interface IRead { int Value { get; } }
class Reader : IRead { public long Value { get { return 317; } } }
class Program { static void Main() { } }
