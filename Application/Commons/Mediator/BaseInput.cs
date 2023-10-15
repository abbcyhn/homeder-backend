namespace Application.Commons.Mediator;

public record BaseInput
{
    private int _userId;
    private int _loggedUserId;
    private string _hostUrl;
    private bool _isUserIdProvided;

    public int GetUserId() 
    {
        return _userId;
    }

    public void SetUserId(int userId)
    {
        _userId = userId;
    }

    public int GetLoggedUserId() 
    {
        return _loggedUserId;
    }

    public void SetLoggedUserId(int loggedUserId)
    {
        _loggedUserId = loggedUserId;
    }

    public string GetHostUrl()
    { 
        return _hostUrl;
    }

    public void SetHostUrl(string hostUrl)
    {
        _hostUrl = hostUrl;
    }

    public bool IsUserIdProvided()
    { 
        return _isUserIdProvided;
    }

    public void SetIsUserIdProvided(bool isUserIdProvided)
    {
        _isUserIdProvided = isUserIdProvided;
    }
}
