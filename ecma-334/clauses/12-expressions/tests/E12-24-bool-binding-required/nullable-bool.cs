/*
Rules: E12-24-bool-binding-required
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: reject
Mutate: if (flag)
Into: if (flag == true)
Csc: CS0266
*/
class Program
{
    static void Main() { bool? flag = true; if (flag) { } }
}
