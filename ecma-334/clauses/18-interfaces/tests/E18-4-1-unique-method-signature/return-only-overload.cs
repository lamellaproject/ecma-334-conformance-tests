/*
Rules: E18-4-1-unique-method-signature
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: long Read(int value);
Into: long Read(long value);
Csc: CS0111
*/
interface IRead { int Read(int value); long Read(int value); }
class Program { static void Main() { } }
