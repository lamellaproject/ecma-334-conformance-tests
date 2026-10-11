/*
Rules: E8-8-unmanaged-field-restriction
Authority: ECMA-334 7th ed 8.8
Version: 7.3
Expected: reject
Mutate: public object Value;
Into: public int Value;
*/
struct State { public object Value; }
class Program { static unsafe void Main() { State* pointer = stackalloc State[1]; } }
