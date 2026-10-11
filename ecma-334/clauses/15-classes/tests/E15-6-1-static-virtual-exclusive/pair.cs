/*
Rules: E15-6-1-static-virtual-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public static virtual int Read()
Into: public static int Read()
Csc: CS0112
*/
class Holder { public static virtual int Read() { return 11; } }
class Program { static void Main() { Holder.Read(); } }
