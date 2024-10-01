namespace QueueTrials;

public class AuthService
{
    private OfficerService _officerService;

     public AuthService(OfficerService officerService)
    {
        _officerService = officerService;
    }
    public bool Authorize(Officer officer){
        return officer != null && officer.IsAdmin;
    }
}
