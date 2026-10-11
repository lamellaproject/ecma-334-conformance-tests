/*
Rules: E18-4-1-no-static-member; E18-1-no-member-implementations
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: static void Read() { }
Into: void Read();
*/
interface IRead { static void Read() { } }
class Program { static void Main() { } }
