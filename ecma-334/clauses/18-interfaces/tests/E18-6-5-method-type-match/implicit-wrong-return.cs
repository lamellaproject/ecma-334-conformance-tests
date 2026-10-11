/*
Rules: E18-6-5-method-type-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public long Read()
Into: public int Read()
Csc: CS0738
*/
interface IRead { int Read(); }
class Reader : IRead { public long Read() { return 307; } }
class Program { static void Main() { } }
