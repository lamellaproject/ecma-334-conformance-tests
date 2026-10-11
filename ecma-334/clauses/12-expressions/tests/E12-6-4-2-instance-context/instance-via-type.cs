/*
Rules: E12-6-4-2-instance-context
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Box.Read(3)
Into: new Box().Read(3)
*/
class Box { public int Read(int x) { return x; } }
class Program { static void Main() { Box.Read(3); } }
