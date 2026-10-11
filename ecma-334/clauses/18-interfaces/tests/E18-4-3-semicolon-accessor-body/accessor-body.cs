/*
Rules: E18-4-3-semicolon-accessor-body
Authority: ECMA-334 7th ed 18.4.3
Version: 7.3
Expected: reject
Mutate: get { return 101; }
Into: get;
Csc: CS8370
*/
interface IRead { int Value { get { return 101; } } }
class Program { static void Main() { } }
