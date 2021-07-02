<%@ WebHandler Language="C#" Class="BoletoNet.ImagemCodigoBarraHandler"%>

using System;
using System.Web;

public class ImagemCodigoBarra : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}