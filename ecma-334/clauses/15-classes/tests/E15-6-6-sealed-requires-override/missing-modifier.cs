/*
Rules: E15-6-6-sealed-requires-override
Authority: ECMA-334 7th ed 15.6.6
Version: 7.3
Expected: reject
Mutate: public sealed int Read()
Into: public sealed override int Read()
Csc: CS0238
*/
class Origin { public virtual int Read() { return 11; } }
class Boundary : Origin { public sealed int Read() { return 29; } }
class Program { static void Main() { } }
