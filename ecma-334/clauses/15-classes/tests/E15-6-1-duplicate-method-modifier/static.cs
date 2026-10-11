/*
Rules: E15-6-1-duplicate-method-modifier
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public static static int Read()
Into: public static int Read()
Csc: CS1004
*/
class Holder { public static static int Read() { return 7; } }
class Program { static void Main() { Holder.Read(); } }
