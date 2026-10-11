/*
Rules: E16-4-3-override-valuetype-only
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: public override void Work()
Into: public void Work()
*/
struct Entry { public override void Work() { } }
class Program { static void Main() { } }
