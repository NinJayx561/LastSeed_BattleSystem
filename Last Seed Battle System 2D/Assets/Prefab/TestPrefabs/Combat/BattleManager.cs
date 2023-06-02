using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public enum BattleState
    {
        Idle,
        Perform,
        Performing
    }
    private BattleState state;

    private Queue<Battler> turnQueue;
    private Queue<CombatTurn> actionQueue;

    public List<Battler> activeParty;
    public List<Battler> activeEnemies;

    [SerializeField] private Transform partyNode;
    [SerializeField] private Transform enemyNode;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        foreach (HeroBattler hero in partyNode.GetComponentsInChildren<HeroBattler>())
            activeParty.Add(hero);
        
        foreach (EnemyBattler enemy in enemyNode.GetComponentsInChildren<EnemyBattler>())
            activeParty.Add(enemy);


    }

    private void Update() 
    {
        switch(state)
        {
            case BattleState.Idle:
                if (turnQueue.Count>0)
                {
                    Battler currentBattler = turnQueue.Dequeue();
                    currentBattler.State = Battler.TurnState.ChooseAction;
                }
                if (actionQueue.Count > 0)
                {
                    CombatTurn currentTurn = actionQueue.Dequeue();
                    currentTurn.Actor.State = Battler.TurnState.Action;
                }
                break;
            case BattleState.Perform:
                break;
            case BattleState.Performing:
                break;
        }
    }

    public void Enqueue(Battler battler)
    {
        turnQueue.Enqueue(battler);
    }
}
