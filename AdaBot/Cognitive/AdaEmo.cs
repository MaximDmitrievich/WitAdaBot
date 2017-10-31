using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace AdaBot.Cognitive
{
    public class AdaEmo
    {
        private EmotionServiceClient _emotionServiceClient;

        private Emotion[] _emotions;

        private bool _isEmotion;

        private readonly string _emotionAPISubscriptionKey = "5591d8dc4e5b41ce9f92b04083a53b14";
        

        public AdaEmo()
        {
            _emotionServiceClient = new EmotionServiceClient(_emotionAPISubscriptionKey);
            _isEmotion = false;
        }

        public Emotion[] Emotions
        {
            private set { _emotions = value; }
            get { return _emotions; }
        }

        public bool IsEmotion
        {
            private set { _isEmotion = value; }
            get { return _isEmotion; }
        }

        private async System.Threading.Tasks.Task StartRecognize(MemoryStream photo)
        {
            try
            {
                _emotions = await _emotionServiceClient.RecognizeAsync(photo);
                if (_emotions.Length > 0)
                {
                    _isEmotion = true;
                }
            }
            catch
            {
                
            }

        }

        public async Task<string> MakeAboveEmotion(MemoryStream photo)
        {
            string result = "nothing";
            await StartRecognize(photo);
            if (_isEmotion)
            {
                double[] aboveEmo = new double[8];
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[0] += x.Scores.Anger;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[1] += x.Scores.Contempt;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[2] += x.Scores.Disgust;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[3] += x.Scores.Fear;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[4] += x.Scores.Happiness;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[5] += x.Scores.Neutral;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[6] += x.Scores.Sadness;
                });
                Emotions.ToList().ForEach(x =>
                {
                    aboveEmo[7] += x.Scores.Surprise;
                });
                int mx = aboveEmo.ToList().IndexOf(aboveEmo.ToList().Max());
                switch (mx)
                {
                    case 0:
                        result = "anger emotions";
                        break;
                    case 1:
                        result = "contempt emotions";
                        break;
                    case 2:
                        result = "disgust emotions";
                        break;
                    case 3:
                        result = "fear emotions";
                        break;
                    case 4:
                        result = "happiness emotions";
                        break;
                    case 5:
                        result = "neutral emotions";
                        break;
                    case 6:
                        result = "sadness emotions";
                        break;
                    case 7:
                        result = "surprise emotions";
                        break;
                    default:
                        result = "nothing";
                        break;
                }
            }
            return await Helpers.TranslateText(result, "ru", await Helpers.GetAuthenticationToken("6e32a3dbe36546b8ae02b31eeb2cd904"));
        }
    }
}
