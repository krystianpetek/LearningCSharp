namespace AppMVVM_2_WFAiIS.Model
{
    public class TextModel
    {
        public string? Text { get; set; } = string.Empty;
        public void CleanText()
        {
            Text = string.Empty;
        }
    }
}
