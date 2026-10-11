/*
Rules: E15-6-1-semicolon-no-async
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public extern async void Touch();
Into: public extern void Touch();
Csc: CS1994
*/
class Holder { public extern async void Touch(); }
class Program { static void Main() { } }
