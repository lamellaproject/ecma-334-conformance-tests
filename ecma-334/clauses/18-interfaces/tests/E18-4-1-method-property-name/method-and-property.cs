/*
Rules: E18-4-1-method-property-name; E18-4-1-unique-property-name
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: void Value();
Into: void Read();
Csc: CS0102
*/
interface ICell { int Value { get; } void Value(); }
class Program { static void Main() { } }
