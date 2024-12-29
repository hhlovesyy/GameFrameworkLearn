using UnityEngine;
using GameFramework.Fsm;
using ProcedureOwner = GameFramework.Fsm.IFsm<Player>;
using UnityGameFramework.Runtime;

public class IdleState : FsmState<Player>
{
    //触发移动的指令列表
    private static KeyCode[] MOVE_COMMANDS = { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow };

    protected internal override void OnInit(ProcedureOwner fsm)
    {
        base.OnInit(fsm);
    }

    protected internal override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);
    }

    protected internal override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        foreach (var command in MOVE_COMMANDS)
        {
            //触发任何一个移动指令时
            if (Input.GetKeyDown(command))
            {
                //记录这个移动指令
                fsm.SetData<VarInt32>("MoveCommand", (int)command);
                //切换到移动状态
                ChangeState<MoveState>(fsm);
            }
        }
    }

    protected internal override void OnLeave(ProcedureOwner fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
    }

    protected internal override void OnDestroy(ProcedureOwner fsm)
    {
        base.OnDestroy(fsm);
    }
}
