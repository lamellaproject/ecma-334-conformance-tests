/*
Rules: E18-4-1-no-finalizer
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: ~IClose() { }
Into: void Close();
Csc: CS0575
*/
interface IClose { ~IClose() { } }
class Program { static void Main() { } }
