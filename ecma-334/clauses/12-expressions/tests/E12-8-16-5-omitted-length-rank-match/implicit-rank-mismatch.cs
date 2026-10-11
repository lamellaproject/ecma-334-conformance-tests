/*
Rules: E12-8-16-5-omitted-length-rank-match
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: new[,] { 7, 19 }
Into: new[] { 7, 19 }
*/
class Program
{
    static void Main() { var cells = new[,] { 7, 19 }; }
}
