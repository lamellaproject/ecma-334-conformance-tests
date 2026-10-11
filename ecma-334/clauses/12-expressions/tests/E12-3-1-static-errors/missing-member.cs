/*
Rules: E12-3-1-static-errors
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: reject
Mutate: receiver.Absent()
Into: receiver.Present()
*/
class Box { public int Present() { return 1; } }
class Program { static void Main() { Box receiver = new Box(); int value = receiver.Absent(); } }
