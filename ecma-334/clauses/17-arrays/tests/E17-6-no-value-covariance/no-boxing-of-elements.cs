/*
Rules: E17-6-no-value-covariance
Authority: ECMA-334 7th ed 17.6
Version: 7.3
Expected: reject
Mutate: new int[1]
Into: new string[1]
*/
class Program
{
    static void Main() { object[] values = new int[1]; }
}
