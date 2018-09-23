using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class OnPointerClickingEnterHolder : MonoBehaviour
{

    public List<OnPointerClickingEnter> onPointerClickingEnters;
    private int lastEnteredIndex = -1; //デフォルト値
    public List<LineByNumber> lines;
    public Subject<LineByNumber> addedLineNumber;
    public Subject<LineByVector3> addedLinePosition;


    private void Awake()
    {
        addedLineNumber = new Subject<LineByNumber>();
        addedLinePosition = new Subject<LineByVector3>();
        lines = new List<LineByNumber>();

    }

    // Use this for initialization
    void Start()
    {
        foreach (var item in onPointerClickingEnters.Select((Value, Index) => new { Value, Index }))
        {
            item.Value.onPointerClickingEnter.Subscribe
                (_ =>
                {
                    Debug.Log(item.Index);

                    if (lastEnteredIndex != -1 & lastEnteredIndex != item.Index)
                    {
                        lines.Add(new LineByNumber(lastEnteredIndex, item.Index));
                        addedLineNumber.OnNext(lines.Last());
                        addedLinePosition.OnNext(new LineByVector3(
                            onPointerClickingEnters.ElementAt(lines.Last().x1).transform.position, 
                            onPointerClickingEnters.ElementAt(lines.Last().x2).transform.position
                            ));
                    }
                    lastEnteredIndex = item.Index;
                }
                );
        }
    }
    
}
