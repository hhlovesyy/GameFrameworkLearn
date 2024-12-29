using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using DemoGame;

public class Player : MonoBehaviour
{
    //Player对象自增Id
    private static int SERIAL_ID = 0;

    private IFsm<Player> fsm;
    
    IEnumerator Start()
    {
        //等待GameEntry初始化完成,等待一帧先试试，否则可能会有时序上的问题
        yield return null;
        //创建状态列表
        List<FsmState<Player>> stateList = new List<FsmState<Player>>() { new IdleState(), new MoveState() };
        //创建状态机，注意，对于所有持有者为Player类型的状态机的名字参数不能重复，这里用自增ID避免重复
        fsm = GameEntry.Fsm.CreateFsm<Player>((SERIAL_ID++).ToString(), this, stateList);
        //以IdleState为初始状态，启动状态机
        fsm.Start<IdleState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        //销毁状态机
        GameEntry.Fsm.DestroyFsm(fsm);
    }
}
