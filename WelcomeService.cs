namespace firstApp
{
    public class WelcomeService : IWelcomeService
    {
        public string GetMessage()
        {
            return "welcom from WelcomeService";
        }
    }
}