/*
Rules: E15-6-1-partial-abstract-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: abstract partial void Touch();
Into: partial void Touch();
*/
abstract partial class Holder { abstract partial void Touch(); }
class Program { static void Main() { } }
