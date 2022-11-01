/**
    Analyzes the tokens inputed to determine which of them are distinct.
*/
class FileSummaryAnalyzer : ITokenAnalyzer
{
    private int tokenCount { get; set; }

    /* 
        Initializes an empty list for the distinct tokens. 
        The set will always be initialized empty and be populated while running.
    */
    public FileSummaryAnalyzer() => tokenCount = 0;

    /* 
        Adds the current token to the list if it is not already present.
    */
    public void process(string token) => tokenCount++;

    /*
        Generate the output file.
    */
    public void report(string filePath)
    {

    }

    /* 
        Formats and prints the list of distinct tokens.
    */
    public void printToFile()
    {

    }
}