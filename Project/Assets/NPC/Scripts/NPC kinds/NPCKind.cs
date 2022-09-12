using Actions_back;
using System.Collections.Generic;


public abstract class NPCKind : CharacterKind
{
    public List<Action> actions { protected set; get; }
    public abstract void Initialize();
}
