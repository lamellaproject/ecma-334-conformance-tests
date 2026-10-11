/*
Rules: E15-5-6-3-initializer-no-simple-instance-member
Authority: ECMA-334 7th ed 15.5.6.3
Version: 7.3
Expected: reject
Mutate: public int Read() { return 41; }
Into: public static int Read() { return 41; }
Csc: CS0236
*/
class Holder
{
    public int Read() { return 41; }
    public int Copy = Read();
}
class Program { static void Main() { new Holder(); } }
