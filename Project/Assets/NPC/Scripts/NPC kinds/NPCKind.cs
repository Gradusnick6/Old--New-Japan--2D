using Actions_back;
using System.Collections.Generic;


public abstract class NPCKind : CharacterKind
{
    public List<Action> Actions { protected set; get; }
    public abstract void Initialize();
}
