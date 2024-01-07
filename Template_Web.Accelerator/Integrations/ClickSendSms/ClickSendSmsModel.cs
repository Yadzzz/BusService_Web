namespace Template_Web.Accelerator.Integrations.ClickSendSms
{
    public class ClickSendSmsModel
    {
        public string Source { get; }
        public string From { get; set; }
        public string Body { get; set; }
        public string To { get; set; }

        public ClickSendSmsModel()
        {
            // This is the source of the message
            Source = "C#"; // sdk???
        }
    }
}
