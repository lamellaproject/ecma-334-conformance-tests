/*
Rules: E15-7-3-interface-no-accessor-modifier
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: private set;
Into: set;
*/
interface IBox { int Item { get; private set; } }
class Program { static void Main() { } }
