/*
Rules: E15-8-5-abstract-event-no-implementation
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: base.Signal -= handler;
Into: this.Signal -= handler;
Csc: CS0205
*/
abstract class Source { public abstract event System.Action Signal; }
class Derived : Source
{
    public override event System.Action Signal { add { } remove { } }
    public void Detach(System.Action handler) { base.Signal -= handler; }
}
class Program { static void Main() { } }
