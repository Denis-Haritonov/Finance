using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BankSystem.Captcha
{
    public static class CaptchaHelper
    {
        public static string GenerateCaptcha(this HtmlHelper helper)  
{  
              
    var captchaControl = new Recaptcha.RecaptchaControl  
            {  
                    ID = "recaptcha",  
                    Theme = "blackglass",
                    PublicKey = "6Lcx9xQTAAAAAC-Wiks3ZEVAlelIewCTzfPbPrRK",
                    PrivateKey = "6Lcx9xQTAAAAANDEAaVhJO686nDs9WZfqI-fgoxp"
        };  
  
    var htmlWriter = new HtmlTextWriter( new StringWriter() );  
  
    captchaControl.RenderControl(htmlWriter);  
  
    return htmlWriter.InnerWriter.ToString();  
}
    }
}