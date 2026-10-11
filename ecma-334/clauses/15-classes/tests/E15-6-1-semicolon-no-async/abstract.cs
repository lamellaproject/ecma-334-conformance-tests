/*
Rules: E15-6-1-semicolon-no-async
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract async void Touch();
Into: public abstract void Touch();
Csc: CS1994
*/
abstract class Holder { public abstract async void Touch(); }
class Program { static void Main() { } }
