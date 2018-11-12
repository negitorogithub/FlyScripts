using UnityEngine;
using System.Collections;

public class BaloonHolder : MonoBehaviour, IBaloonHolder
{
    public GameObject baloon;

    public GameObject getBaloon() => baloon;
}
