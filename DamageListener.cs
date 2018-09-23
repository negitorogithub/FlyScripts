using UnityEngine;
using System.Collections;

public class DamageListener : MonoBehaviour
{
    private HpHolder hpHolder;

    private void Start()
    {
        hpHolder = GetComponent<HpHolder>();
    }

    public void OnDamage(float damage) 
    {
        hpHolder.ReduceHp(damage);
    }
}
 