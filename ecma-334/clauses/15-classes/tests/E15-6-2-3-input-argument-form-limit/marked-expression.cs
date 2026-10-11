/*
Rules: E15-6-2-3-input-argument-form-limit
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: Read(in Make())
Into: Read(Make())
Csc: CS8156
*/
class Program
{
    static int Make() { return 31; }
    static int Read(in int value) { return value; }
    static void Main() { Read(in Make()); }
}
