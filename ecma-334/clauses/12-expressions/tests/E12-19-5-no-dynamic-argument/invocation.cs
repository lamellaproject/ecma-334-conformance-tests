/*
Rules: E12-19-5-no-dynamic-argument
Authority: ECMA-334 7th ed 12.19.5
Version: 7.3
Expected: reject
Mutate: () => 11
Into: (Result)(() => 11)
*/
delegate int Result();
class Receiver { public int Read(Result function) { return function(); } }
class Program { static void Main() { dynamic receiver = new Receiver(); var result = receiver.Read(() => 11); } }
