/*
Rules: E13-6-2-1-nonref-local-safe-context; E13-6-2-1-ref-local-safe-context
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int local = field;
Into: ref int local = ref field;
*/
class Program
{
    static int field = 3;
    static ref int Get() { int local = field; ref int alias = ref local; return ref alias; }
    static void Main() { }
}
