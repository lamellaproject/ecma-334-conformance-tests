/*
Rules: E7-5-2-interface-member-modifier-forbidden
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: public int Read();
Into: int Read();
*/
interface IItem { public int Read(); }
class Program { static void Main() { } }
