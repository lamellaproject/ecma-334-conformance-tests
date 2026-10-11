/*
Rules: E12-8-16-2-type-parameter-value
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: Touch(ref new T());
Into: Touch(ref value);
Csc: CS1510
*/
class Program
{
    static void Touch<T>(ref T value) { }
    static void Create<T>() where T : new() { T value = new T(); Touch(ref new T()); }
    static void Main() { Create<int>(); }
}
