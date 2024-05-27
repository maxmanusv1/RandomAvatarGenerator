using ImageGenerator.Keywords;

namespace ImageGenerator.PromptGenerator
{
    public class PromptDetails
    {
        public string Prompt { get; set; }
        public EImageTypes ImageTypes { get; set; }

        public EModelTypes ModelTypes { get; set; } 
    }
}
