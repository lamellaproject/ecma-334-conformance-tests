/*
Rules: E15-6-1-semicolon-no-async
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: async partial void Touch();
Into: partial void Touch();
Csc: CS1994
*/
partial class Holder { async partial void Touch(); }
class Program { static void Main() { } }
