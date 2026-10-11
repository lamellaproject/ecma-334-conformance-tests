/*
Rules: E15-6-1-partial-public-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public partial void Touch();
Into: partial void Touch();
*/
partial class Holder { public partial void Touch(); }
class Program { static void Main() { } }
