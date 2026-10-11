/*
Rules: E14-7-class-nested-access-restriction
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: reject
Mutate: public protected class Hidden
Into: protected class Hidden
*/
class Owner { public protected class Hidden { } }
class Program
{
    static void Main() {  }
}
