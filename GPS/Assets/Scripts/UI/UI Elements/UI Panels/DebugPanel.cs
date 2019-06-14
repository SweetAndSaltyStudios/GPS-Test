using System.Collections;
using TMPro;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class DebugPanel : UI_Panel
    {
        public TextMeshProUGUI LatitudeText;
        public TextMeshProUGUI LongitudeText;
        public TextMeshProUGUI StatusText;
        public TextMeshProUGUI MessageText;

        private readonly float updateTimer = 3f;

        public void StartUpdateDebugUI()
        {
            StartCoroutine(IUpdateDebugUI());
        }

        private IEnumerator IUpdateDebugUI()
        {
            while (InputManager.Instance.LocationStatus == LocationServiceStatus.Running)
            {
                yield return new WaitForSeconds(updateTimer);

                if (LocationServiceManager.Instance.HasPositionChanged)
                {
                    UpdateDebugContent(LocationServiceManager.Instance.Latitude, LocationServiceManager.Instance.Longitude);
                }

                if (LocationServiceManager.Instance.HasStatusChanged)
                {
                    StatusText.text = "STATUS: " + LocationServiceManager.Instance.CurrentServiceStatus.ToString();
                }
            }
        }

        private void UpdateDebugContent(float latitude, float longitude)
        {
            LatitudeText.text = "LATITUDE: " + latitude;
            LongitudeText.text = "LONGITUDE: " + longitude;
        }

        public void UpdateDebugMessage(string message)
        {
            MessageText.text = "MESSAGE: " + message;
        }
    }
}
