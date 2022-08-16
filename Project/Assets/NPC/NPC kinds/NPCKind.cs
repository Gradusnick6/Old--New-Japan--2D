using UnityEngine;
using Actions;
using System.Collections.Generic;

public class NPCKind : MonoBehaviour
{
    public int health { protected set; get; }
    public List<Action> actions { protected set; get; }

}