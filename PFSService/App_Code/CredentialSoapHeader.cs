using System;
using System.Web.Services.Protocols;

[Serializable]
public class CredentialSoapHeader : SoapHeader
{
    public string UserName = string.Empty;
    public string PassWord = string.Empty;
    public decimal Id = 0;
}
