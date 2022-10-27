namespace Actions_back
{
    public static class ActionResources
    {
        public static string GetResourcesPath(ActionKind kind)
        {
            switch (kind)
            {
                case ActionKind.StandartHit: return "HitAreas/StandartHitArea";
                default: return "";
            }
        }
    }
}