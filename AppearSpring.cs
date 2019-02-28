using UnityEngine;
using System.Collections;
using UniRx;
using System.Collections.Generic;

public class AppearSpring : MonoBehaviour
{
    public ConstantScenarioModelOfNPC constant;
    public GameObject springContent;
    public List<GameObject> gameObjects;

    // Use this for initialization
    void Start()
    {
        springContent.SetActive(false);
        constant.onShowText_m.Skip(1).Subscribe(_ =>
        {
            springContent.SetActive(true);
            constant.gameObject.SetActive(false);
            gameObjects.ForEach(obj => Destroy(obj));
        });
    }
}
