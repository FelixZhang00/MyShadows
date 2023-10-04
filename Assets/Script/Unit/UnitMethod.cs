using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitMethod 
{
    public static UnitInfo CreateUnitInfo(UnitMoveState unitMoveState, float pushEnergyCost, float destoryEnergyCost, float throughEnergyCost) {
        return new DefaultUnitInfo(unitMoveState,pushEnergyCost,destoryEnergyCost,throughEnergyCost);
    }
}
