using UnityEngine;

public class HeroBattler : Battler
{
    protected override void ChooseTarget()
    {
        base.ChooseTarget();
        int targetIndex = Random.Range(0, BattleManager.Instance.activeEnemies.Count);
        currentTurn.Target = BattleManager.Instance.activeEnemies[targetIndex];
    }
}

