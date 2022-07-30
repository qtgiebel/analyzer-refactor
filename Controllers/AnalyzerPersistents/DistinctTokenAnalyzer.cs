/**
    Analyzes the tokens inputed to determine which of them are distinct.
*/
class DistinctTokenAnalyzer : ITokenAnalyzer
{
    private SortedSet<string> distinctTokens { get; set; }

    /* 
        Initializes an empty list for the distinct tokens. 
        The set will always be initialized empty and be populated while running.
    */
    public DistinctTokenAnalyzer() => distinctTokens = new SortedSet<string>();

    /* 
        Adds the current token to the list if it is not already present.
    */
    public void process(string token) => distinctTokens.Add(token);

    /*
        Generate the output file.
    */
    public void generateOutputFile(string filePath)
    {

    }

    /* 
        Formats and prints the list of distinct tokens.
    */
    public void printToFile()
    {

    }
}