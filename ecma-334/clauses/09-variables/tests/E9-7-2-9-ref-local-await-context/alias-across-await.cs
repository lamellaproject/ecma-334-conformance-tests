/*
Rules: E9-7-2-9-ref-local-await-context
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref int alias = ref cell;
Into: int alias = cell;
Csc: CS8370
*/
class Program
{
    static async void Probe()
    {
        int cell = 66;
        ref int alias = ref cell;
        await System.Threading.Tasks.Task.FromResult(0);
        System.Console.WriteLine(alias);
    }
    static void Main() { }
}
