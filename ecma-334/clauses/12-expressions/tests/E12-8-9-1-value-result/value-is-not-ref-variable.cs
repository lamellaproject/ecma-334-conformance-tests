/*
Rules: E12-8-9-1-value-result
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: reject
Mutate: Touch(ref Read());
Into: int result = Read();
*/
class Program
{
    static int Read() { return 5; }
    static void Touch(ref int value) { }
    static void Main() { Touch(ref Read()); }
}
