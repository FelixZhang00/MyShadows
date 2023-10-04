using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultUnitInfo : UnitInfo
{
    public DefaultUnitInfo(UnitMoveState unitMoveState, float pushEnergyCost, float destoryEnergyCost, float throughEnergyCost) 
        : base(unitMoveState, pushEnergyCost, destoryEnergyCost, throughEnergyCost)
    {

    }
}
