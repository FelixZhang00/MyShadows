using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitObject : MonoBehaviour
{
    public UnitMoveState unitMovestate;
    [Header("����������˶�����")]
    public bool canPush;
    public bool canDestory;
    public bool canThrough;

    [Header("������������")]
    public  float PushEnergyCost = 0f;
    public  float DestoryEnergyCost = 0f;
    public  float ThroughEnergyCost = 0f;

    public UnitInfo unitInfo;

    private void Awake()
    {
        unitInfo = UnitMethod.CreateUnitInfo(unitMovestate, PushEnergyCost, DestoryEnergyCost,ThroughEnergyCost);
        unitInfo.SetActionTypeList(canPush, canDestory, canThrough);
    }


}
