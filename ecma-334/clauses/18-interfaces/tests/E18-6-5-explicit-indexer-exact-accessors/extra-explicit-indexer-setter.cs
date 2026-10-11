/*
Rules: E18-6-5-explicit-indexer-exact-accessors
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: get { return 373; } set { }
Into: get { return 373; }
Csc: CS0550
*/
interface IRead { int this[int index] { get; } }
class Reader : IRead { int IRead.this[int index] { get { return 373; } set { } } }
class Program { static void Main() { } }
