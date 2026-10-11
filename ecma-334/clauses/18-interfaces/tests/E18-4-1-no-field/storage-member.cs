/*
Rules: E18-4-1-no-field
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: int Value;
Into: int Value { get; }
Csc: CS0525
*/
interface ICell { int Value; }
class Program { static void Main() { } }
