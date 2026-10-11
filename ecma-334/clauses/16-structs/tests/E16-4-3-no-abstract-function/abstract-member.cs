/*
Rules: E16-4-3-no-abstract-function
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: public abstract void Work();
Into: public void Work() { }
*/
struct Entry { public abstract void Work(); }
class Program { static void Main() { } }
