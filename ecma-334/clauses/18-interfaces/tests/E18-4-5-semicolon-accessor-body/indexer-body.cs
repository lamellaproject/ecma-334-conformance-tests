/*
Rules: E18-4-5-semicolon-accessor-body
Authority: ECMA-334 7th ed 18.4.5
Version: 7.3
Expected: reject
Mutate: get { return index; }
Into: get;
Csc: CS8370
*/
interface IRead { int this[int index] { get { return index; } } }
class Program { static void Main() { } }
