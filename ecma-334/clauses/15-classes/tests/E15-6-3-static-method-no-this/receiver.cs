/*
Rules: E15-6-3-static-method-no-this
Authority: ECMA-334 7th ed 15.6.3
Version: 7.3
Expected: reject
Mutate: public static int Read()
Into: public int Read()
Csc: CS0026
*/
class Holder
{
    int value = 23;
    public static int Read() { return this.value; }
}
class Program { static void Main() { } }
