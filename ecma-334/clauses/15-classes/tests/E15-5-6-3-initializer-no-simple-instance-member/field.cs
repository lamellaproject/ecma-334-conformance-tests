/*
Rules: E15-5-6-3-initializer-no-simple-instance-member
Authority: ECMA-334 7th ed 15.5.6.3
Version: 7.3
Expected: reject
Mutate: public int Source = 31;
Into: public static int Source = 31;
Csc: CS0236
*/
class Holder
{
    public int Source = 31;
    public int Copy = Source;
}
class Program { static void Main() { new Holder(); } }
