/*
Rules: E15-6-1-partial-override-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: override partial void Touch();
Into: partial void Touch();
*/
class Parent { public virtual void Touch() { } }
partial class Holder : Parent { override partial void Touch(); }
class Program { static void Main() { } }
