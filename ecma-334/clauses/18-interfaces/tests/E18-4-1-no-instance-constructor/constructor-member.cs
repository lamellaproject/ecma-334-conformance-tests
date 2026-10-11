/*
Rules: E18-4-1-no-instance-constructor
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: IStart() { }
Into: void Start();
Csc: CS0526
*/
interface IStart { IStart() { } }
class Program { static void Main() { } }
