using System;

public class TokenModel
{
    public ResultModel result { get; set; }
    public int id { get; set; }
    public object exception { get; set; }
    public int status { get; set; }
    public bool isCanceled { get; set; }
    public bool isCompleted { get; set; }
    public bool isCompletedSuccessfully { get; set; }
    public int creationOptions { get; set; }
    public object asyncState { get; set; }
    public bool isFaulted { get; set; }
}

public class ResultModel
{
    public bool authenticateResult { get; set; }
    public string authToken { get; set; }
    public DateTime accessTokenExpireDate { get; set; }
}
