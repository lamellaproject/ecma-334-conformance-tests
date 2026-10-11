/*
Rules: E8-4-5-new-constraint-nonabstract
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: reject
Mutate: abstract class Receiver
Into: class Receiver
*/
abstract class Receiver { public Receiver() { } }
class Gate<T> where T : new() { }
class Program { static void Main() { Gate<Receiver> gate = null; } }
