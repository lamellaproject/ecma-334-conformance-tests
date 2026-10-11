/*
Rules: E12-6-6-1-static-nonvirtual
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: reject
Mutate: static virtual int Pick()
Into: static int Pick()
Csc: CS0112
*/
class Worker
{
    public static virtual int Pick() { return 3; }
}
class Program
{
    static void Main() { Worker.Pick(); }
}
