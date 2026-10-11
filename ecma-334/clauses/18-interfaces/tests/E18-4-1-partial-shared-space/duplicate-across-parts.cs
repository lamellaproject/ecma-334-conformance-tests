/*
Rules: E18-4-1-partial-shared-space
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: partial interface IRead { int Read(int second); }
Into: partial interface IRead { int Other(int second); }
Csc: CS0111
*/
partial interface IRead { int Read(int first); }
partial interface IRead { int Read(int second); }
class Program { static void Main() { } }
