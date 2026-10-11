/*
Rules: E18-4-1-parameter-member-name; E18-4-1-declaration-space
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: void Item();
Into: void Read();
Csc: CS0102
*/
interface IRead<Item> { void Item(); }
class Program { static void Main() { } }
