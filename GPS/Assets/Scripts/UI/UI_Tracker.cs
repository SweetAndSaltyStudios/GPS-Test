using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class UI_Tracker : MonoBehaviour
    {
        private Transform lookAtTarget;

        private void Awake()
        {
            lookAtTarget = Camera.main.transform;
        }

        private void Update()
        {
            transform.LookAt(lookAtTarget);
        }
    }
}
