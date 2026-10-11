/*
Rules: E15-6-2-1-default-expression-limit
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: Stamp value = new Stamp(19)
Into: Stamp value = new Stamp()
Csc: CS1736
*/
struct Stamp { public int Value; public Stamp(int value) { Value = value; } }
class Holder { public void Touch(Stamp value = new Stamp(19)) { } }
class Program { static void Main() { } }
