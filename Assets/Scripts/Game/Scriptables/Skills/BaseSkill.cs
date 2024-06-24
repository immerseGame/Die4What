using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



[CreateAssetMenu(fileName = "BaseSkill", menuName = "ScriptableObjects/BaseSkill", order = 1)]
public class BaseSkill : ScriptableObject
{
    public string skillName;
    public string skillDescription;
    public float skillCooldown;
    public int skillQuantity;

    public virtual void UseSkill()
    {

    }

}
