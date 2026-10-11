/*
Rules: E15-6-1-partial-protected-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: protected partial void Touch();
Into: partial void Touch();
*/
partial class Holder { protected partial void Touch(); }
class Program { static void Main() { } }
