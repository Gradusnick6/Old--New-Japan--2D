using System.Collections.Generic;
using UnityEngine;

namespace Actions_back
{
    [CreateAssetMenu(fileName = "ActionStorage", menuName = "Actions/Backend/ActionStorage", order = 51)]
    public class ActionStorage : ScriptableObject
    {
        public List<StandartHit> standartHits;

        ActionStorage()
        {
            standartHits = new List<StandartHit>();
            
        }

        public string GetResourcesPath(ActionKind kind)
        {
            switch (kind)
            {
                case ActionKind.StandartHit: return "HitAreas/StandartHitArea";
                default: return "";
            }

        }
    }
}