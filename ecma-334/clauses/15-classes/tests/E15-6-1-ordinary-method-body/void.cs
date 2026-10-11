/*
Rules: E15-6-1-ordinary-method-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public void Touch();
Into: public void Touch() { }
Csc: CS0501
*/
class Holder { public void Touch(); }
class Program { static void Main() { } }
