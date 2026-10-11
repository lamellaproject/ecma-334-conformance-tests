/*
Rules: E16-4-3-no-virtual-function
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: public virtual void Work()
Into: public void Work()
*/
struct Entry { public virtual void Work() { } }
class Program { static void Main() { } }
