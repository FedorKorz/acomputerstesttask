namespace UserInterfaceVisual.Models;

public class Response
{
    private readonly bool _isResponseCorrect;
    private readonly string _responseData;
    private readonly Type _responseType;
    private readonly string _statusCode;

    public Response(string responseData, bool isResponseCorrect, Type responseType, string statusCode)
    {
        _responseData = responseData;
        _isResponseCorrect = isResponseCorrect;
        _responseType = responseType;
        _statusCode = statusCode;
    }

    public string GetResponseData()
    {
        return _responseData;
    }

    public bool GetResponseCorrectness()
    {
        return _isResponseCorrect;
    }

    public string GetStatusCode()
    {
        return _statusCode;
    }

    public string GetResponseType()
    {
        return _responseType.ToString();
    }
}