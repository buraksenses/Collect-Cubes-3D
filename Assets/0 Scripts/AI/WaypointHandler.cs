using System.Collections.Generic;
using UnityEngine;

namespace CollectCubes.AI
{
    public class WaypointHandler : Singleton<WaypointHandler>
    {
        public List<Transform> leftWaypoints;
        public List<Transform> rightWaypoints;
    }
}

