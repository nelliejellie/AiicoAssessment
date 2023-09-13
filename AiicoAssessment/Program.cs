namespace AiicoAssessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 10,10,20,12,12};
            Console.WriteLine( GetMatchingPairs(9, list));
        }

        static int GetMatchingPairs(int number, List<int> items)
        {
            /*0,10*/
            var matchingPairs = new List<int>();
            
            var duplicates = items.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key);
            foreach ( var pair in duplicates)
            {
                matchingPairs.Add(pair);
            }
            var answer = new HashSet<int>(matchingPairs);
            return answer.Count;
        }
    }
}