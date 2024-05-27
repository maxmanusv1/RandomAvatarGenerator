using ImageGenerator.PromptGenerator;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ImageGenerator.Keywords
{
    public class Generate
    {
        KeywordGenerator KeywordGenerator = new KeywordGenerator();
        public string DrawingPrompt = "lineart| vibrant| comprehensive cinematic| Carne Griffiths| {replace}"; // 10
        public string RealityPrompt = "{replace}, hd, dramatic lighting, detailed"; // 15
        public string ProgressiveRockPrompt = "70s progressive rock artwork, funky, vibrant, acid-culture"; //15
        public string FaceForWomanPrompt = "analog style portrait of a cute young woman with blonde hair"; //5
        public string FaceForManPrompt = "analog style portrait of a cute young man"; //5
        public string AnalogPrompt = "analog style {replace}"; //25
        public string AnimePrompt = "";  //25

        public async Task<PromptDetails> GetPromptDetailsAsync()
        {
           
            EImageTypes types = await RandomizeImageTypesAsync();
            EModelTypes modelTypes = await ModelTypesAsync(types);
            string prompt = await BuildPromptAsync(types);
            var promptDetails = new PromptDetails
            {
                ImageTypes = types,
                ModelTypes = modelTypes,
                Prompt = prompt
            };
            return promptDetails;
        }
        private async Task<EModelTypes> ModelTypesAsync(EImageTypes ımageTypes)
        {
            switch (ımageTypes)
            {
                case EImageTypes.Drawing:
                    return EModelTypes.SD;
                case EImageTypes.Reality:
                    return EModelTypes.SD;
                case EImageTypes.Face:
                    return EModelTypes.AnalogV1;
                case EImageTypes.Analog:
                    return EModelTypes.AnalogV1;
                case EImageTypes.Anime:
                    return EModelTypes.AnythingV3;
                case EImageTypes.Progressive:
                    return EModelTypes.SD;
                default: return EModelTypes.SD;
            }
        }
        private Random random = new Random();
        private async Task<EImageTypes> RandomizeImageTypesAsync()
        {
            int randomizedNumber = random.Next(0,101);
            Debugger.Log(11,"123",randomizedNumber.ToString() + Environment.NewLine);
            if (randomizedNumber >= 0 && randomizedNumber <= 25)
                return EImageTypes.Anime;
            else if (randomizedNumber > 25 && randomizedNumber <= 50)
                return EImageTypes.Analog;
            else if (randomizedNumber > 50 && randomizedNumber <= 65)
                return EImageTypes.Progressive;
            else if (randomizedNumber > 65 && randomizedNumber <= 80)
                return EImageTypes.Reality;
            else if (randomizedNumber > 80 && randomizedNumber <= 90)
                return EImageTypes.Drawing;
            else
                return EImageTypes.Face;
        }
        private async Task<string> BuildPromptAsync(EImageTypes types)
        {
            if (types == EImageTypes.Drawing)
                return DrawingPrompt.Replace("{replace}", await KeywordGenerator.GetFamousNamesAsync());
            else if (types == EImageTypes.Reality)
                return RealityPrompt.Replace("{replace}", await KeywordGenerator.GetSentences());
            else if (types == EImageTypes.Progressive)
                return ProgressiveRockPrompt;
            else if (types == EImageTypes.Analog)
                return AnalogPrompt.Replace("{replace}", await KeywordGenerator.GetGameCharacterAsync());
            else if (types == EImageTypes.Anime)
                return await KeywordGenerator.GetAnimePromptAsync();
            else
            {
                int sayi = random.Next(0,2);
                if (sayi == 1)
                    return FaceForWomanPrompt;
                else
                    return FaceForManPrompt;
            }
        }
    }
}
