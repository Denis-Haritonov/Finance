using System.Web.Mvc;

public class CaptchaValidatorAttribute : ActionFilterAttribute
{
    private const string CHALLENGE_FIELD_KEY = "recaptcha_challenge_field";
    private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";

    public override void OnActionExecuting(ActionExecutingContext filterContext)  
        {  
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[CHALLENGE_FIELD_KEY];  
            var captchaResponseValue = filterContext.HttpContext.Request.Form[RESPONSE_FIELD_KEY];  
            var captchaValidtor = new Recaptcha.RecaptchaValidator  
                                      {
                                          PrivateKey = "6Lcx9xQTAAAAANDEAaVhJO686nDs9WZfqI-fgoxp",  
                                          RemoteIP = filterContext.HttpContext.Request.UserHostAddress,  
                                          Challenge = captchaChallengeValue,  
                                          Response = captchaResponseValue  
                                      };  
  
            var recaptchaResponse = captchaValidtor.Validate();  
  
        // this will push the result value into a parameter in our Action  
            filterContext.ActionParameters["captchaValid"] = recaptchaResponse.IsValid;  
            filterContext.Controller.ViewData.ModelState.AddModelError("Captcha","Капча введена неверно");
            base.OnActionExecuting(filterContext);  
        }
}