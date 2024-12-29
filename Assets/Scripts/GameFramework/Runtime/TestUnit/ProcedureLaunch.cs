using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureLaunch : ProcedureBase
{
    protected internal override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Debug.Log("ProcedureLaunch.OnEnter");
        InitUI(procedureOwner);
    }

    private void InitUI(ProcedureOwner procedureOwner)
    {
        //just for test
        Debug.Log("InitUI");
        //找到Canvas/BeginGameBtn
        GameObject beginGameBtn = GameObject.Find("Canvas/BeginGameBtn");
        if (beginGameBtn == null)
        {
            Debug.LogError("Can't find BeginGameBtn");
            return;
        }

        //给BeginGameBtn添加点击事件
        beginGameBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            Debug.Log("BeginGameBtn Clicked");
            //切换到下一个流程
            ChangeState<ProcedureBegin>(procedureOwner);
        });
    }
}
