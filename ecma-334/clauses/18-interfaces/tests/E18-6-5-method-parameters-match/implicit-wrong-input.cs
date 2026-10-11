/*
Rules: E18-6-5-method-parameters-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public int Read(long value)
Into: public int Read(int value)
Csc: CS0535
*/
interface IRead { int Read(int value); }
class Reader : IRead { public int Read(long value) { return 311; } }
class Program { static void Main() { } }
