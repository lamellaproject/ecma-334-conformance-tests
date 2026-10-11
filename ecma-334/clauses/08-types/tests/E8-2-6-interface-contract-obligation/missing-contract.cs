/*
Rules: E8-2-6-interface-contract-obligation
Authority: ECMA-334 7th ed 8.2.6
Version: 7.3
Expected: reject
Mutate: class Device : IValue
Into: class Device
*/
interface IValue { int Read(); }
class Device : IValue { }
class Program { static void Main() { } }
