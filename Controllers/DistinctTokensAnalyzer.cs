using System.Collections.Generic;

/**
    Analyzes the tokens inputed to determine which of them are distinct.
*/
class DistinctTokensAnalyzer : TokenAnalyzer
{
    private SortedSet<string> distinctTokens { get; set; }

    /* 
        Initializes an empty list for the distinct tokens. 
        The set will always be initialized empty and be populated while running.
    */
    public DistinctTokensAnalyzer() => distinctTokens = new SortedSet<string>();

    /* 
        Adds the current token to the list if it is not already present.
    */
    public void processToken(string token) => distinctTokens.Add(token);

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