#if UNITY_EDITOR

using System.IO;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;

namespace UnityEngine.Recorder.Examples
{

    public class CaptureScreenShotExample : MonoBehaviour
    {

    public GameObject A_Object;
        RecorderController m_RecorderController;

        void OnEnable()
        {
            var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
            m_RecorderController = new RecorderController(controllerSettings);

            var mediaOutputFolder = Path.Combine(Application.dataPath, "..", "SampleRecordings");

            // Image
            var imageRecorder = ScriptableObject.CreateInstance<ImageRecorderSettings>();
            imageRecorder.name = "My Image Recorder";
            imageRecorder.Enabled = true;
            imageRecorder.OutputFormat = ImageRecorderSettings.ImageRecorderOutputFormat.PNG;
            imageRecorder.CaptureAlpha = false;

            imageRecorder.OutputFile = Path.Combine(mediaOutputFolder, "image_") + DefaultWildcard.Take;

            imageRecorder.imageInputSettings = new CameraInputSettings
            {
                Source = ImageSource.TaggedCamera,
                OutputWidth = 2000,
                OutputHeight = 2000,
                CameraTag = "CameraView",
                FlipFinalOutput = true,
            };

            /*
            imageRecorder.imageInputSettings = new GameViewInputSettings
            {
                
                OutputWidth = 2000,
                OutputHeight = 2000,
            };
            */

            // Setup Recording
            controllerSettings.AddRecorderSettings(imageRecorder);
            controllerSettings.SetRecordModeToSingleFrame(0);
        }

        public void Capture_Photo()
        {

                m_RecorderController.PrepareRecording();
                m_RecorderController.StartRecording();

        }


    }
}

#endif
