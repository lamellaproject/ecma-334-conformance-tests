/*
Rules: E15-6-6-sealed-no-further-override
Authority: ECMA-334 7th ed 15.6.6
Version: 7.3
Expected: reject
Mutate: public sealed override int Read()
Into: public override int Read()
Csc: CS0239
*/
class Origin { public virtual int Read() { return 7; } }
class Boundary : Origin { public sealed override int Read() { return 23; } }
class Tip : Boundary { public override int Read() { return 59; } }
class Program { static void Main() { } }
