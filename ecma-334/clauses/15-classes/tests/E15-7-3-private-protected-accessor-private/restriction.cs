/*
Rules: E15-7-3-private-protected-accessor-private
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: protected set
Into: private set
*/
class Box { int slot; private protected int Item { get { return slot; } protected set { slot = value; } } }
class Program { static void Main() { } }
