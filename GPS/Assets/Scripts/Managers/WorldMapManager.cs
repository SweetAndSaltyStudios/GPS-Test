using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class WorldMapManager : Singelton<WorldMapManager>
    {
        public WrldMap WorldMap
        {
            get;
            private set;
        }

        private void Awake()
        {
            WorldMap = GetComponentInChildren<WrldMap>();
        }

        private void Foo()
        {
         
        }
    }
}