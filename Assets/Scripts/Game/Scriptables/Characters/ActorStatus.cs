using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class DamageInfo
{
    public float baseDamage;
    public float extraDamage;
    public bool isCrit; 


    public float GetDamageValue()
    {
        float multiplier = 1;

        multiplier = isCrit ? 1.5f : 1;

        return (baseDamage + extraDamage) * multiplier;
    }
}


[System.Serializable]
public class BaseStatus : ICloneable
{

    [Header("General Info")]
    public string characterName;
    public string characterDescription;
    
    [Header("General Stats")]
    public float baseHp;
    public float currentHp;
    public float hpRegen;
    public float armor;
    public float speed;

    //Events
    public event Action<float> onChangeHp;
    public event Action onDeath;

    
    //Functions
    public void Initialize()
    {
        currentHp = baseHp;

        onChangeHp?.Invoke(currentHp);
    }

    public bool IsDead()
    {
        return currentHp <= 0;
    }

    public void Heal(float healValue)
    {
        currentHp += healValue;
        if (currentHp > baseHp)
        {
            currentHp = baseHp;
        }

        onChangeHp?.Invoke(currentHp);
    }

    public bool Damage(float damageValue)
    {
        float damage = (damageValue - armor);

        if (damage <= 0)
        {
            damage = 1;
        }

        currentHp -= damage;
        onChangeHp?.Invoke(currentHp);

        if (currentHp <= 0)
        {
            onDeath?.Invoke();
        }

        return currentHp <= 0;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}


[CreateAssetMenu(fileName = "BaseCharacterInfo", menuName = "ScriptableObjects/BaseCharacterInfo", order = 1)]

public class BaseCharacterInfo : ScriptableObject
{
    public BaseStatus status;

    public virtual void InitializeCharacter(BaseStatus _status)
    {
        status = (BaseStatus)_status.Clone();
        status.Initialize();

        status.onDeath += OnDeath;
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual bool GetDamage(DamageInfo _damageInfo)
    {
        return status.Damage(_damageInfo.GetDamageValue());
    }

    public virtual void OnDeath()
    {

    }

}
