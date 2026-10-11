/*
Rules: E15-15-1-async-no-ref-struct-parameters
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: Read(Packet value)
Into: Read(int value)
*/
using System.Threading.Tasks;
ref struct Packet { }
class Program { static async Task<int> Read(Packet value) { await Task.FromResult(0); return 13; } static void Main() { } }
