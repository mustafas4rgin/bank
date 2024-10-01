namespace QueueTrials;

public class OfficerService
{
    public Officer Authenticate(string username, string password, List<Officer> officers){
        var officer = officers.Where(c=>c.Username == username && c.Password == password).FirstOrDefault();
        if(officer != null){
            return officer;
        }
        return null;
}
}
