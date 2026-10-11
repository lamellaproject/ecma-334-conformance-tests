/*
Rules: E15-6-1-partial-sealed-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: sealed partial void Touch();
Into: partial void Touch();
*/
partial class Holder { sealed partial void Touch(); }
class Program { static void Main() { } }
