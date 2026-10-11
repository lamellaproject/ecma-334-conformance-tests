/*
Rules: E13-10-5-async-ref-return-error
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return ref storage;
Into: return storage;
*/
using System.Threading.Tasks;
class Program
{
    static int storage;
    // async methods have value/void effective returns; the ref prohibition overlaps that classification.
    static async Task<int> Produce() { return ref storage; }
    static void Main() { }
}
