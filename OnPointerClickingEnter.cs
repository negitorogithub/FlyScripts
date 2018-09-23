using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerClickingEnter : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public Subject<Unit> onPointerClickingEnter { get; private set; }
    private const int MOUSE_LEFT = 0;

    //PC用
    public void OnPointerDown(PointerEventData eventData)
    {
            onPointerClickingEnter.OnNext(Unit.Default);
    }
    
    //PC用
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(MOUSE_LEFT))
        {
            onPointerClickingEnter.OnNext(Unit.Default);
        }
    }

    // Use this for initialization
    void Awake () {
        onPointerClickingEnter = new Subject<Unit>(); 
    }

    
}
