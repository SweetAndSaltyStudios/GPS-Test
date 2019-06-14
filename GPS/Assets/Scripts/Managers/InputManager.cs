using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

namespace Sweet_And_Salty_Studios
{
    public class InputManager : Singelton<InputManager>
    {
        public LocationServiceStatus LocationStatus
        {
            get 
            {
                return Input.location.status;
            }
        }
        public float Latitude
        {
            get 
            {
                return Input.location.isEnabledByUser ? Input.location.lastData.latitude : 0;
            }
        }
        public float Longitude
        {
            get 
            {
                return Input.location.isEnabledByUser ? Input.location.lastData.longitude : 0;
            }
        }
        public bool IsEnabledByUser
        {
            get 
            {
                return Input.location.isEnabledByUser;
            }
        }

        public void StartLocation()
        {
            Input.location.Start();
        }
    }
}
