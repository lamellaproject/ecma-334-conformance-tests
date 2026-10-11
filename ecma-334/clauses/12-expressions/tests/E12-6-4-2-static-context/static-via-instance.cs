/*
Rules: E12-6-4-2-static-context
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: new Box().Read(3)
Into: Box.Read(3)
*/
class Box { public static int Read(int x) { return x; } }
class Program { static void Main() { new Box().Read(3); } }
