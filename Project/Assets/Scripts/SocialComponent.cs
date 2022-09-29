using UnityEngine;
public class SocialComponent
{
    public enum Factions
    {
        // друзья для таких же; враги для всех остальных
        PACIFISTS,
        // друзья для таких же; враги для всех остальных
        WARRIORS,
        // враг для всех
        SINGLES
    }
    private GameObject characterObj;
    public SocialComponent(GameObject characterObj_)
    {
        characterObj = characterObj_;
    }

    /// <summary>
    /// проверяет "враждебность" opponent по отношению к characterObj на основе фракции
    /// </summary>
    /// <param name="opponent"> проверяемый на враждебность объект</param>
    /// <returns>true - opponent враждебен; false - opponent не враждебен</returns>
    public bool isHostility(GameObject opponent)
    {
        if (characterObj.tag == GetFactionString(Factions.PACIFISTS))
        {
            if (opponent.tag == GetFactionString(Factions.SINGLES))
                return true;
            else if (opponent.tag == GetFactionString(Factions.WARRIORS))
                return true;
            else return false;
        }

        if (characterObj.tag == GetFactionString(Factions.WARRIORS))
        {
            if (opponent.tag == GetFactionString(Factions.SINGLES))
                return true;
            else if (opponent.tag == GetFactionString(Factions.PACIFISTS))
                return true;
            else return false;
        }

        if (characterObj.tag == GetFactionString(Factions.SINGLES))
        {
            return true;
        }
        return false;
    }
    static public string GetFactionString(Factions f)
    {
        return f.ToString();
    }
}
