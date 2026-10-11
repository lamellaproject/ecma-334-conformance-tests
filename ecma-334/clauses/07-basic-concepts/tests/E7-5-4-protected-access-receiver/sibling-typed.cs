/*
Rules: E7-5-4-protected-access-receiver
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: reject
Mutate: Read(Sibling receiver)
Into: Read(Branch receiver)
*/
class Root { protected int value = 101; }
class Sibling : Root { }
class Branch : Root { public int Read(Sibling receiver) { return receiver.value; } }
class Program { static void Main() { } }
