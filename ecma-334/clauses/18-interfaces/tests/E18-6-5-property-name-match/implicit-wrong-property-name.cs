/*
Rules: E18-6-5-property-name-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public int Other
Into: public int Value
Csc: CS0535
*/
interface IRead { int Value { get; } }
class Reader : IRead { public int Other { get { return 313; } } }
class Program { static void Main() { } }
