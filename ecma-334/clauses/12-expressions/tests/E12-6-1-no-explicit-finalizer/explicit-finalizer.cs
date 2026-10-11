/*
Rules: E12-6-1-no-explicit-finalizer
Authority: ECMA-334 7th ed 12.6.1
Version: 7.3
Expected: reject
Mutate: receiver.Finalize();
Into: receiver.Touch();
*/
class Box { ~Box() { } public void Touch() { } }
class Program { static void Main() { Box receiver = new Box(); receiver.Finalize(); } }
