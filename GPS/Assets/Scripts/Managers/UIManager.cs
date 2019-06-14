using UnityEngine;
using UnityEditor;

namespace Sweet_And_Salty_Studios
{
    public class UIManager : Singelton<UIManager>
    {
        public DebugPanel DebugPanel
        {
            get;
            private set;
        }

        private void Awake()
        {
            DebugPanel = FindObjectOfType<DebugPanel>();
        }

        private void Start()
        {
            DebugPanel.gameObject.SetActive(false);          
        }

        public void StartGPSButton()
        {
            LocationServiceManager.Instance.StartLocationService();
        }

        public void DebugButton()
        {
            DebugPanel.gameObject.SetActive(!DebugPanel.gameObject.activeSelf); 
        }

        public void QuitButton()
        {
#if UNITY_EDITOR

            EditorApplication.isPlaying = false;
#else

            Application.Quit();

#endif
        }
    }
}
