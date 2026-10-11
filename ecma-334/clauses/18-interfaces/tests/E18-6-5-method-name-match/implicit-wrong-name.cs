/*
Rules: E18-6-5-method-name-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public int Other()
Into: public int Read()
Csc: CS0535
*/
interface IRead { int Read(); }
class Reader : IRead { public int Other() { return 293; } }
class Program { static void Main() { } }
