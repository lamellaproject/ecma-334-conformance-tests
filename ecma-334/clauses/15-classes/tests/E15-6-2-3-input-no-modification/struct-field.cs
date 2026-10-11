/*
Rules: E15-6-2-3-input-no-modification
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: in Cell value
Into: ref Cell value
Csc: CS8332
*/
struct Cell { public int Value; }
class Holder { public void Edit(in Cell value) { value.Value = 53; } }
class Program { static void Main() { } }
