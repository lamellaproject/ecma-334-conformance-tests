/*
Rules: E15-2-3-partial-parameter-names
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: reject
Mutate: partial class Packet<Right, Left> { }
Into: partial class Packet<Left, Right> { }
*/
partial class Packet<Left, Right> { int marker; }
partial class Packet<Right, Left> { }
class Program { static void Main() { } }
