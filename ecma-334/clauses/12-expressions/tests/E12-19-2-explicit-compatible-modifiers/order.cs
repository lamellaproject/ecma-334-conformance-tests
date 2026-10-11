/*
Rules: E12-19-2-explicit-compatible-modifiers
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: (out int first, ref int second) =>
Into: (ref int first, out int second) =>
*/
delegate void Assign(ref int first, out int second);
class Program { static void Main() { Assign function = (out int first, ref int second) => { first = 23; second = 29; }; } }
