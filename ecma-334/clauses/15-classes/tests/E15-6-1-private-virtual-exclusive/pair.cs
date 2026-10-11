/*
Rules: E15-6-1-private-virtual-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: private virtual int Read()
Into: private int Read()
Csc: CS0621
*/
class Holder { private virtual int Read() { return 23; } }
class Program { static void Main() { } }
