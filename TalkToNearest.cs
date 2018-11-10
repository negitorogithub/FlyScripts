using UnityEngine;
using System.Collections;
using System;
using UniRx;
using System.Linq;

public class TalkToNearest : MonoBehaviour
{
    private ColidingObjectHolder colidings;
    private Subject<Unit> subject;
    public float intervalSeonds;

    private void Awake()
    {
        subject = new Subject<Unit>();
    }

    // Use this for initialization
    void Start()
    {
        colidings = GetComponent<ColidingObjectHolder>();
        subject.ThrottleFirst(TimeSpan.FromSeconds(intervalSeonds)).Subscribe(_ =>
        {
            float min = float.MaxValue;
            GameObject minObj = null;
            var showTexts = colidings.gameObjects
                .Where(obj => obj.GetComponent<ShowText>() != null);

            foreach (var item in showTexts)
            {
                if (Vector3.Distance(transform.position, item.transform.position) < min)
                {
                    minObj = item;
                }
            }
            minObj?.GetComponent<ShowText>()?.ShowNextText();
        }

        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            subject.OnNext(Unit.Default);
        }


    }
}
