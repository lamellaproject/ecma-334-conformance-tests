/*
Rules: E15-6-1-return-type-accessibility
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public Hidden Read()
Into: internal Hidden Read()
Csc: CS0050
*/
class Hidden { }
public class Holder { public Hidden Read() { return null; } }
class Program { static void Main() { } }
