/*
Rules: E15-6-1-unsafe-method-context
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: public unsafe void Touch() { }
Into: public void Touch() { }
Csc: CS0227
*/
class Holder { public unsafe void Touch() { } }
class Program { static void Main() { new Holder().Touch(); } }
