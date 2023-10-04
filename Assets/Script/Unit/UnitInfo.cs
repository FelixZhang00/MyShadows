using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitMoveState
{
    NotInteractive,
    Ready,
    Lock
}

public enum UnitActionType
{
    Push,
    Destory,
    Through
}

public abstract class UnitInfo
{
    public readonly float PushEnergyCost = 0f;
    public readonly float DestoryEnergyCost = 0f;
    public readonly float ThroughEnergyCost = 0f;

    private UnitMoveState unitMoveState;
    protected List<UnitActionType> unitActionTypes;


    protected UnitInfo(UnitMoveState unitMoveState, float pushEnergyCost, float destoryEnergyCost, float throughEnergyCost)
    {
        this.unitMoveState = unitMoveState;
        unitActionTypes = new List<UnitActionType>();

        PushEnergyCost = pushEnergyCost;
        DestoryEnergyCost = destoryEnergyCost;
        ThroughEnergyCost = throughEnergyCost;
    }

    public void SetUnitMoveState(UnitMoveState unitMoveState)
    {
        if (unitMoveState == UnitMoveState.NotInteractive)
        {
            return;
        }
        this.unitMoveState = unitMoveState;
    }

    public UnitMoveState GetUnitMoveState() { return unitMoveState; }
    public void SetActionTypeList(bool canPush, bool canDestory, bool canThrough)
    {
        if (unitMoveState == UnitMoveState.NotInteractive)
        {
            unitActionTypes.Clear();
        }
        unitActionTypes.Clear();
        if (canPush)
        {
            unitActionTypes.Add(UnitActionType.Push);
        }
        if (canDestory)
        {
            unitActionTypes.Add(UnitActionType.Destory);
        }
        if (canThrough)
        {
            unitActionTypes.Add(UnitActionType.Through);
        }

    }

    public bool TryThisActionState(UnitActionType unitActionType)
    {
        if (unitActionTypes.Contains(unitActionType))
        {
            return true;
        }
        return false;
    }
}
