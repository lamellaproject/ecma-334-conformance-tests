/*
Rules: E15-5-6-3-initializer-no-this
Authority: ECMA-334 7th ed 15.5.6.3
Version: 7.3
Expected: reject
Mutate: public object Owner = this;
Into: public object Owner = null;
Csc: CS0027
*/
class Holder { public object Owner = this; }
class Program { static void Main() { new Holder(); } }
