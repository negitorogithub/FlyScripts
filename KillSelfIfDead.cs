using UnityEngine;
using System.Collections;
using UniRx;
public class KillSelfIfDead : MonoBehaviour
{
    private HpHolder hpHolder;
    // Use this for initialization
    void Start()
    {
        hpHolder = GetComponent<HpHolder>();
        hpHolder.deadSubject.Subscribe(_ => Destroy(hpHolder.gameObject));
    }
}
