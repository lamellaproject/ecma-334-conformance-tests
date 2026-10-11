/*
Rules: E7-1-entry-candidate-required; E7-1-entry-name
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: static void Start()
Into: static void Main()
*/
class Program
{
    static void Start() { }
}
