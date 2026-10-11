/*
Rules: E18-4-1-no-member-modifiers
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: public void Read();
Into: void Read();
Csc: CS8703
*/
// 18.4.1, pp. 491-492 prints a blanket modifier ban that conflicts with its grammar
// and hiding rules. This test follows those rules, which permit new.
// An explicit access modifier is still prohibited by this edition.
interface IRead { public void Read(); }
class Program { static void Main() { } }
