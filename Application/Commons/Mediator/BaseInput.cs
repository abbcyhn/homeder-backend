namespace Application.Commons.Mediator;

public record BaseInput
{
    private int? _userId;
    private int _loggedUserId;
    private string _hostUrl;
    private string _acceptLanguage;

    public int? GetUserId() 
    {
        return _userId;
    }

    public void SetUserId(int? userId)
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

    public string GetAcceptLanguage()
    { 
        return _acceptLanguage;
    }

    public void SetAcceptLanguage(string acceptLanguage)
    {
        _acceptLanguage = acceptLanguage;
    }
}
