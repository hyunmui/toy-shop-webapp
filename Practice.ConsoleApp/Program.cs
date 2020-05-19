using System;
using Practice.Services;
using RazorLight;

namespace Practice.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // email template test
            RunEmailExample();
        }

        private static void RunEmailExample()
        {
            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program))
                .UseMemoryCachingProvider()
                .Build();

            var emailService = new EmailService(engine);
            var templatePath = "templates.sample";
            var model = new SampleModel
            {
                Name = "Hyeonmin",
                Message = "Hello Razor world!"
            };

            Console.WriteLine(emailService.SendEmail(templatePath, model) ? "파싱 성공" : "파싱 실패");
        }
    }
}