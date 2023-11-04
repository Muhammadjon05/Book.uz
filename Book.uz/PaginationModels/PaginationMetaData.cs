namespace Book.uz.PaginationModels;

public class PaginationMetaData
{
    public int TotalListCount { get; set; }
    public int AmountData { get; set; }
    public int TotalPage { get; set; }
    public int CurrentPageNumber { get; set; }
    public bool HasNextPage => CurrentPageNumber < TotalPage;
    public bool HasPreviousPage => CurrentPageNumber > 1;

    public PaginationMetaData(int totalListCount, int amountData, int currentPageNumber)
    {
        TotalListCount = totalListCount;
        AmountData = amountData;
        CurrentPageNumber = currentPageNumber;
        TotalPage = (int)Math.Ceiling(totalListCount / (double)amountData);
    }
}