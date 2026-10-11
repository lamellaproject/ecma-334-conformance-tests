/*
Rules: E14-4-extern-definition-required
Authority: ECMA-334 7th ed 14.4
Version: 7.3
Expected: reject
Mutate: extern alias Missing;
Into: // No extern alias is declared.
*/
extern alias Missing;
class Program
{
    static void Main() {  }
}
