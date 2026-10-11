/*
Rules: E15-7-3-ref-get-body-rules
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: return ref local;
Into: return ref slot;
*/
class Box { int slot; public ref int Item { get { int local = 17; return ref local; } } }
class Program { static void Main() { } }
