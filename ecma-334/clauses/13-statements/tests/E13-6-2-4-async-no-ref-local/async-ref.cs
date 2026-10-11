/*
Rules: E13-6-2-4-async-no-ref-local
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: ref int alias = ref value;
Into: int alias = value;
*/
class Program
{
    static async void Work() { int value = 6; ref int alias = ref value; }
    static void Main() { }
}
