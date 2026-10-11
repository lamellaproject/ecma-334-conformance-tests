/*
Rules: E22-5-3-2-conditional-no-override-modifier; E22-5-3-2-conditional-override-no-attribute
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: reject
Mutate: [System.Diagnostics.Conditional("X")] public override
Into: public override
*/
using System;
class Parent { [System.Diagnostics.Conditional("X")] public virtual void Hit() { } }
class Child : Parent { [System.Diagnostics.Conditional("X")] public override void Hit() { } }
class Program
{
    static void Main()
    {

    }
}
