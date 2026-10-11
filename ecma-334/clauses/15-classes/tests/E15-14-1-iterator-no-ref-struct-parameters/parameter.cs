/*
Rules: E15-14-1-iterator-no-ref-struct-parameters
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/parameter-42e58e0ff9.cs.part
Mutate: Sequence(Packet p)
Into: Sequence(int p)
*/
using System.Collections.Generic;
ref struct Packet { }
class Program { static IEnumerable<int> Sequence(Packet p) { yield return 13; } static void Main() { } }
