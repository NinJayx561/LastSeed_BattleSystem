using UnityEngine;

public class Battler : MonoBehaviour
{
    public enum TurnState
    {
        Idle,
        Queued,
        ChooseAction, 
        ChooseTarget,
        Action,
        Dead
    }

    public TurnState State {get; set;}

    protected float cooldown;
    [SerializeField] protected float maxCooldown = 3f;

    protected CombatTurn currentTurn;

    protected virtual void Start()
    {
        State = TurnState.Idle;
    }

    private void Update() 
    {
        switch(State)
        {
            case TurnState.Idle:
                Idle();
                break;
            case TurnState.Queued:

                break;
            case TurnState.ChooseAction:
                break;
            case TurnState.ChooseTarget:
                break;
            case TurnState.Action:
                break;
            case TurnState.Dead:
                break;
        }
    }

    protected virtual void Idle()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= maxCooldown)
        {
            //Queue this battler to act
            BattleManager.Instance.Enqueue(this);
            State = TurnState.Queued;
        }
    }
    protected virtual void Queued() {}
    protected virtual void ChooseAction()
    {
        currentTurn = new CombatTurn("Attack", this);
        State = TurnState.ChooseTarget;
    }
    protected virtual void ChooseTarget()
    {
        State = TurnState.Queued;
    }
    protected virtual void Action() {}
    protected virtual void Dead() {}

}
