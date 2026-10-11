/*
Rules: E14-7-struct-nested-access-restriction
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: reject
Mutate: protected class Hidden
Into: private class Hidden
*/
struct Owner { protected class Hidden { } }
class Program
{
    static void Main() {  }
}
