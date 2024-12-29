using System.Collections;
using System.Collections.Generic;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityEngine;

public class ProcedureBegin : ProcedureBase
{
    protected internal override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Debug.Log("ProcedureBegin.OnEnter");
    }
}
