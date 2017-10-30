using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace AdaBot.Cognitive
{
    public class AdaVis
    {
        private VisionServiceClient _visionServiceClient;

        private AnalysisResult _analysisResult;

        private VisualFeature[] _visualFeatures;

        private readonly string _visionAPISubscriptionString = "2295028c3869473a843d591702422de9";

        private bool _isVision;

        public AnalysisResult AnalysisResult { private set; get; }

        public bool IsVision { private set; get; }

        public AdaVis()
        {
            _visionServiceClient = new VisionServiceClient(_visionAPISubscriptionString, "https://westus.api.cognitive.microsoft.com/vision/v1.0");
            _isVision = false;
            _visualFeatures = new VisualFeature[] {
                                                    VisualFeature.Adult,
                                                    VisualFeature.Categories,
                                                    VisualFeature.Color,
                                                    VisualFeature.Description,
                                                    VisualFeature.Faces,
                                                    VisualFeature.ImageType,
                                                    VisualFeature.Tags
                                                   };
        }

        private async System.Threading.Tasks.Task StartRecognize(MemoryStream photo)
        {
            try
            {
                _analysisResult = await _visionServiceClient.DescribeAsync(photo);
                _isVision = true;
            }
            catch
            {
                
            }
        }

        public async Task<string> MakeSomeSummary(MemoryStream photo)
        {
            string result = "nothing";
            await StartRecognize(photo);
            if (_isVision)
            {
                if (_analysisResult.Description.Captions.Length > 0)
                {
                    result = _analysisResult.Description.Captions[0].Text;
                }
            }
            
            return await Helpers.TranslateText(result, "ru", await Helpers.GetAuthenticationToken("6e32a3dbe36546b8ae02b31eeb2cd904"));
        }


    }
}