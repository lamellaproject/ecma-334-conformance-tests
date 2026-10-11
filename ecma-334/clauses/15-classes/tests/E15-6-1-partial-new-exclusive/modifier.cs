/*
Rules: E15-6-1-partial-new-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: new partial void Touch();
Into: partial void Touch();
*/
class Parent { public void Touch() { } }
partial class Holder : Parent { new partial void Touch(); }
class Program { static void Main() { } }
