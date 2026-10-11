/*
Rules: E13-6-4-async-return-type
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: async int Local()
Into: async Task<int> Local()
*/
using System.Threading.Tasks;
class Program { static void Main() { async int Local() { return 6; } } }
