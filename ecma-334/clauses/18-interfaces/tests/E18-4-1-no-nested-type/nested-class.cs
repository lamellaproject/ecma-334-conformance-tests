/*
Rules: E18-4-1-no-nested-type
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: class Nested { }
Into: void Read();
Csc: CS8370
*/
interface IContainer { class Nested { } }
class Program { static void Main() { } }
