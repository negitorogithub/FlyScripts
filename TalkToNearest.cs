using UnityEngine;
using System.Collections;
using System;
using UniRx;
using System.Linq;

public class TalkToNearest : MonoBehaviour
{
    private ColidingObjectHolder colidings;
    private Subject<Unit> subject;
    public static Subject<GameObject> talkedObject;
    public Subject<string> talkedContent;

    public float intervalSeonds;

    private void Awake()
    {
        subject = new Subject<Unit>();
        talkedObject = new Subject<GameObject>();
        talkedContent = new Subject<string>();
    }

    void Start()
    {
        colidings = GetComponent<ColidingObjectHolder>();
        subject.ThrottleFirst(TimeSpan.FromSeconds(intervalSeonds)).Subscribe(_ =>
        {
            float min = float.MaxValue;
            GameObject minObj = null;
            var showTexts = colidings.gameObjects
                .Where(obj => obj.GetComponent<ILoadText>() != null);

            foreach (var item in showTexts)
            {
                if (Vector3.Distance(transform.position, item.transform.position) < min)
                {
                    minObj = item;
                    min = Vector3.Distance(transform.position, item.transform.position);
                }
            }

            if (minObj == null)
            {
                return;
            }
            minObj.GetComponent<ILoadText>()?.LoadNextText();//LoadNextTextが一回余分に呼ばれているが、LoadnextTextのバグの為うまくいっている
            talkedObject.OnNext(minObj);
        }
        );
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            subject.OnNext(Unit.Default);
        }
    }
}
