using RazorLight;

namespace Practice.Services
{
    public class EmailService
    {
        private readonly RazorLightEngine _razorLightEngine;

        public EmailService(RazorLightEngine razorLightEngine)
        {
            _razorLightEngine = razorLightEngine;
        }

        public bool SendEmail(string templatePath, object model)
        {
            var templateTask = _razorLightEngine.CompileRenderAsync(templatePath, model);
            var html = templateTask.Result;

            // TODO: send email
            return !string.IsNullOrEmpty(html);
        }
    }
}