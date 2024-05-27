using ImageGenerator.Keywords;
using ImageGenerator.LogManager;
using ImageGenerator.PromptGenerator;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ImageGenerator.ProdiaAI
{
    public class ProdiaGenerator
    {
        MainForm mainForm;
        LogManager.LogManager LogManager = new LogManager.LogManager();
        Generate Generate = new Generate();
        private string API_KEY = "API_KEY";
        public async Task PostProdiaAsync(RichTextBox textBox, Label label)
        {
            PromptDetails details = await Generate.GetPromptDetailsAsync();
            var options = new RestClientOptions("https://api.prodia.com/v1/sd/generate");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("X-Prodia-Key", API_KEY);

            var data = new
            {
                model = await SpecifyModelAsync(details.ModelTypes),
                prompt = details.Prompt,
                negativeprompt = "blurred image, ((female)), ((woman)), ((girl)), (nudity, porn, sex, nude, naked body, cleavage), bad quality, poor resolution, worst quality, low quality, skin spots, acnes, skin blemishes, age spot, glans, extra fingers, fewer fingers, ugly eyes, deformed iris, deformed pupils, fused lips and teeth), (un-detailed skin, semi-realistic, cgi, 3d, render, sketch, cartoon, drawing, anime), text, close up, cropped, out of frame, worst quality, low quality, jpeg artifacts, ugly, duplicate, morbid, mutilated, extra fingers, mutated hands, poorly drawn hands, poorly drawn face, mutation, deformed, blurry, dehydrated, bad anatomy, bad proportions, (((extra limbs))), cloned face, disfigured, gross proportions, malformed limbs, missing arms, missing legs, extra arms, extra legs, fused fingers, too many fingers, long neck, deformed, mutated",
                sampler = "Euler",
                steps = 25,
                upscale = true,
                aspect_ratio = "landscape",
                cfg_scale = 12
            };
            string requestBody = JsonConvert.SerializeObject(data);
            request.AddBody(requestBody);
            var response = await client.PostAsync(request);
            if (response.IsSuccessful)
            {
                var responsestring = JsonConvert.DeserializeObject<ProdiaJob>(response.Content.ToString());
                string url = await GetUrlAsync(responsestring.Job);
                string path = await DownloadImage(url);
                await LogManager.PushLogs(textBox,LogTypes.Success,"Succesfully created image. FileName: "+path);
                MethodInvoker methodInvoker = new MethodInvoker(delegate {
                    label.Text = (Convert.ToInt32(label.Text) + 1).ToString();
                });
                label.Invoke(methodInvoker);
            }
            else
            {
                await LogManager.PushLogs(textBox,LogTypes.Error,"Something is wrong with response. " + response.Content.ToString());
                mainForm.isDisposed = true; 
            }

        }
        private async Task<string> GetUrlAsync(string job)
        {
            while (true)
            {
                var options = new RestClientOptions("https://api.prodia.com/v1/job/" + job);
                var client = new RestClient(options);
                options.MaxTimeout = Timeout.Infinite;
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("X-Prodia-Key", API_KEY);
                var response = await client.GetAsync(request);
                var responsecontent = JsonConvert.DeserializeObject<Image>(response.Content.ToString());
                if (responsecontent.Status == "queued")
                {
                    Thread.Sleep(3000);
                }
                else if (responsecontent.Status == "succeeded")
                {
                    return responsecontent.ImageURL;
                }
            }
        }
        private async Task<string> DownloadImage(string url)
        {
            Guid guid = Guid.NewGuid();
            try
            {
                using (WebClient client = new WebClient())
                    client.DownloadFileAsync(new Uri(url),$@"GeneratedImages\\{string.Concat(guid.ToString().Split(Path.GetInvalidFileNameChars()))}.png");
                return string.Concat(guid.ToString().Split(Path.GetInvalidFileNameChars()));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<string> SpecifyModelAsync(EModelTypes e)
        {
            switch (e)
            {
                case EModelTypes.AnalogV1:
                    return "analog-diffusion-1.0.ckpt [9ca13f02]";
                case EModelTypes.SD:
                    return "v1-5-pruned-emaonly.safetensors [d7049739]";
                case EModelTypes.AnythingV3:
                    return "anythingv3_0-pruned.ckpt [2700c435]";
                default: return "v1-5-pruned-emaonly.safetensors [d7049739]";
            }
        }
    }
}
