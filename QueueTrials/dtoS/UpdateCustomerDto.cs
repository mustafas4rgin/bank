namespace QueueTrials;

public class UpdateCustomerDto : BankerDto
{
    public string Address { get; set; } = string.Empty; 
    public int Balance { get; set; } = 0;
}
