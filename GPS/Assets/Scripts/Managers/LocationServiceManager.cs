using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class LocationServiceManager : Singelton<LocationServiceManager>
    {
        private float previousLatitude;
        private float previousLongitude;
        private LocationServiceStatus previousServiceStatus;

        public float Latitude
        {
            get 
            {
                return previousLatitude = InputManager.Instance.Latitude;
            }
        }
        public float Longitude
        {
            get 
            {
                return previousLongitude = InputManager.Instance.Longitude;
            }
        }

        public LocationServiceStatus CurrentServiceStatus
        {
            get 
            {
                return previousServiceStatus = InputManager.Instance.LocationStatus;
            }
        }

        public bool HasPositionChanged
        {
            get
            {
                return previousLatitude != Latitude || previousLongitude != Longitude;
            }

        }
        public bool HasStatusChanged
        {
            get 
            {
                return previousServiceStatus != CurrentServiceStatus;
            }          
        }

        public void StartLocationService()
        {
            StartCoroutine(IStartLocationService());
        }

        private IEnumerator IStartLocationService()
        {
            if (InputManager.Instance.IsEnabledByUser == false)
            {
                UIManager.Instance.DebugPanel.UpdateDebugMessage("User has not enabled GPS!");
                yield break;
            }

            InputManager.Instance.StartLocation();

            var maxWait = 20;

            UIManager.Instance.DebugPanel.UpdateDebugMessage("Initializing...");

            while (InputManager.Instance.LocationStatus == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            if (maxWait <= 0)
            {
                UIManager.Instance.DebugPanel.UpdateDebugMessage("Timed out");
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                UIManager.Instance.DebugPanel.UpdateDebugMessage("Unable to determin device location");
                yield break;
            }

            UIManager.Instance.DebugPanel.UpdateDebugMessage("Done");

            UIManager.Instance.DebugPanel.StartUpdateDebugUI();

            yield break;
        }
    }
}