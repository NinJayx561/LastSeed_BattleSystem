using System;
using UnityEngine;

public class CombatTurn
{
    public string ActionName;
    public Battler Actor;
    public Battler Target;

    public CombatTurn(string actionName, Battler battler)
    {
        ActionName = actionName;
        Actor = battler;
    }
}
