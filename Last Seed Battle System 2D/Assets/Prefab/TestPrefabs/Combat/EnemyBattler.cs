using UnityEngine;

public class EnemyBattler : Battler
{
    protected override void ChooseTarget()
    {
        base.ChooseTarget();
        int targetIndex = Random.Range(0, BattleManager.Instance.activeParty.Count);
        currentTurn.Target = BattleManager.Instance.activeParty[targetIndex];
    }
}
