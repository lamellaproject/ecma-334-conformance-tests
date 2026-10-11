/*
Rules: E8-4-5-new-constraint-public-parameterless
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: reject
Mutate: private Receiver()
Into: public Receiver()
*/
class Receiver { private Receiver() { } }
class Gate<T> where T : new() { }
class Program { static void Main() { Gate<Receiver> gate = null; } }
