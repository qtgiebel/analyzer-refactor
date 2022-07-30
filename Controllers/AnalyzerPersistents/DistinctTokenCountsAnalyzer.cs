/* Keeps a tally of the number of times each distinct token is repeated. */
class DistinctTokenCountsAnalyzer : ITokenAnalyzer
{
    private Dictionary<string, int> distinctTokens { get; set; }

    /* Initializes an empty dictionary to record the distinct tokens. */
    public DistinctTokenCountsAnalyzer() => distinctTokens = new Dictionary<string, int>();

    /* If a token exists in the dictionary, increments the count of that token. 
        Otherwise adds the new token with a value of 1. */
    public void process(string token)
    {
        if (distinctTokens.ContainsKey(token))
        {
            distinctTokens.Add(token, distinctTokens[token] + 1);
            return;
        }

        distinctTokens.Add(token, 1);
    }

    /*  */
    public void generateOutputFile(string filePath)
    {
        throw new NotImplementedException();
    }
}