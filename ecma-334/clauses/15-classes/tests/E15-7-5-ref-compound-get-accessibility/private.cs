/*
Rules: E15-7-5-ref-compound-get-accessibility
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: box.Hidden
Into: box.Open
*/
class Box { int slot; private ref int Hidden { get { return ref slot; } } public ref int Open { get { return ref slot; } } }
class Program { static void Main() { Box box = new Box(); box.Hidden += 9; } }
