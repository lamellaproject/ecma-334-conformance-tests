/*
Rules: E18-1-no-member-implementations; E18-4-2-no-method-body
Authority: ECMA-334 7th ed 18.1
Version: 7.3
Expected: reject
Mutate: int Read() { return 43; }
Into: int Read();
Csc: CS8370
*/
interface IRead { int Read() { return 43; } }
class Program { static void Main() { } }
