/*
Rules: E18-4-1-unique-indexer-signature
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: long this[int value] { get; }
Into: long this[long value] { get; }
Csc: CS0111
*/
interface IRead { int this[int value] { get; } long this[int value] { get; } }
class Program { static void Main() { } }
