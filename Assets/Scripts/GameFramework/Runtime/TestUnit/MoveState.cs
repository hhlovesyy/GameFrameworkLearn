using UnityEngine;
using GameFramework.Fsm;
using ProcedureOwner = GameFramework.Fsm.IFsm<Player>;
using UnityGameFramework.Runtime;

public class MoveState : FsmState<Player>
{
    private static readonly float EXIT_TIME = 1f;
    private float exitTimer;
    private KeyCode moveCommand;

    protected internal override void OnInit(ProcedureOwner fsm)
    {
        base.OnInit(fsm);
    }

    protected internal override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);

        //进入移动状态时，获取移动指令数据
        moveCommand = (KeyCode)(int)fsm.GetData<VarInt32>("MoveCommand");
    }

    protected internal override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        //计时器累计时间
        exitTimer += elapseSeconds;

        switch(moveCommand)
        {
            //just print for test
            case KeyCode.LeftArrow:
                Debug.Log("Move Left");
                break;
            case KeyCode.RightArrow:
                Debug.Log("Move Right");
                break;
            case KeyCode.UpArrow:
                Debug.Log("Move Up");
                break;
            case KeyCode.DownArrow:
                Debug.Log("Move Down");
                break;
        }

        //达到指定时间后
        if (exitTimer > EXIT_TIME)
        {
            //切换回空闲状态
            ChangeState<IdleState>(fsm);
        }
    }

    protected internal override void OnLeave(ProcedureOwner fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);

        //推出移动状态时，把计时器清零
        exitTimer = 0;
        //清空移动指令
        moveCommand = KeyCode.None;
        fsm.RemoveData("MoveCommand");
    }

    protected internal override void OnDestroy(ProcedureOwner fsm)
    {
        base.OnDestroy(fsm);
    }
}