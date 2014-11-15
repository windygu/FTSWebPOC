#region

using System.Web.Services.Protocols;
using System.Xml;

#endregion

namespace FTS.Global{
    public enum FaultCode{
        Client = 0,
        Server = 1
    }

    public class ExceptionManager{
        public static SoapException RaiseException(string uri, string webServiceNamespace, string errorMessage,
                                                   string errorNumber, string errorSource, FaultCode code){
            XmlQualifiedName faultCodeLocation = null;
            switch (code){
                case FaultCode.Client:
                    faultCodeLocation = SoapException.ClientFaultCode;
                    break;
                case FaultCode.Server:
                    faultCodeLocation = SoapException.ServerFaultCode;
                    break;
            }
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name,
                                                 SoapException.DetailElementName.Namespace);
            XmlNode errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error", webServiceNamespace);
            XmlNode errorNumberNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorNumber", webServiceNamespace);
            errorNumberNode.InnerText = errorNumber;
            XmlNode errorMessageNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorMessage", webServiceNamespace);
            errorMessageNode.InnerText = errorMessage;
            XmlNode errorSourceNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource", webServiceNamespace);
            errorSourceNode.InnerText = errorSource;
            errorNode.AppendChild(errorNumberNode);
            errorNode.AppendChild(errorMessageNode);
            errorNode.AppendChild(errorSourceNode);
            rootNode.AppendChild(errorNode);
            SoapException soapEx = new SoapException(errorMessage, faultCodeLocation, uri, rootNode);
            return soapEx;
        }

        public static SoapException RaiseException(string uri, string webServiceNamespace, string errorMessage,
                                                   string errorNumber, string errorSource, int errorRow, FaultCode code){
            XmlQualifiedName faultCodeLocation = null;
            switch (code){
                case FaultCode.Client:
                    faultCodeLocation = SoapException.ClientFaultCode;
                    break;
                case FaultCode.Server:
                    faultCodeLocation = SoapException.ServerFaultCode;
                    break;
            }
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name,
                                                 SoapException.DetailElementName.Namespace);
            XmlNode errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error", webServiceNamespace);
            XmlNode errorNumberNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorNumber", webServiceNamespace);
            errorNumberNode.InnerText = errorNumber;
            XmlNode errorMessageNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorMessage", webServiceNamespace);
            errorMessageNode.InnerText = errorMessage;
            XmlNode errorSourceNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource", webServiceNamespace);
            errorSourceNode.InnerText = errorSource;
            XmlNode errorRowNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorRow", webServiceNamespace);
            errorRowNode.InnerText = errorRow.ToString();
            errorNode.AppendChild(errorNumberNode);
            errorNode.AppendChild(errorMessageNode);
            errorNode.AppendChild(errorSourceNode);
            errorNode.AppendChild(errorRowNode);
            rootNode.AppendChild(errorNode);
            SoapException soapEx = new SoapException(errorMessage, faultCodeLocation, uri, rootNode);
            return soapEx;
        }

        public static SoapException RaiseException(string uri, string webServiceNamespace, string errorMessage,
                                                   string errorNumber, string errorSource, string errorField,
                                                   int errorRow, FaultCode code){
            XmlQualifiedName faultCodeLocation = null;
            switch (code){
                case FaultCode.Client:
                    faultCodeLocation = SoapException.ClientFaultCode;
                    break;
                case FaultCode.Server:
                    faultCodeLocation = SoapException.ServerFaultCode;
                    break;
            }
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name,
                                                 SoapException.DetailElementName.Namespace);
            XmlNode errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error", webServiceNamespace);
            XmlNode errorNumberNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorNumber", webServiceNamespace);
            errorNumberNode.InnerText = errorNumber;
            XmlNode errorMessageNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorMessage", webServiceNamespace);
            errorMessageNode.InnerText = errorMessage;
            XmlNode errorSourceNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource", webServiceNamespace);
            errorSourceNode.InnerText = errorSource;
            XmlNode errorFieldNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorField", webServiceNamespace);
            errorFieldNode.InnerText = errorField;
            XmlNode errorRowNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorRow", webServiceNamespace);
            errorRowNode.InnerText = errorRow.ToString();
            errorNode.AppendChild(errorNumberNode);
            errorNode.AppendChild(errorMessageNode);
            errorNode.AppendChild(errorSourceNode);
            errorNode.AppendChild(errorFieldNode);
            errorNode.AppendChild(errorRowNode);
            rootNode.AppendChild(errorNode);
            SoapException soapEx = new SoapException(errorMessage, faultCodeLocation, uri, rootNode);
            return soapEx;
        }
    }
}