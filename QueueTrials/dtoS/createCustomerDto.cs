namespace QueueTrials;

public class createCustomerDto : BankerDto
{
    public string Address { get; set; } = string.Empty;
    public int Balance { get; set; } = 0;
}
