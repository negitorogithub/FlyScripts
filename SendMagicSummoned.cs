using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SendMagicSummoned : MonoBehaviour {

    public LoadMagicPattern magicPatternLoader;
    public OnPointerClickingEnterHolder enterHolder;
    public Subject<MagicPatterns> subject;

    private void Awake()
    {
        subject = new Subject<MagicPatterns>();
    }

    private void Start()
    {
        enterHolder.addedLineNumber.Subscribe(_ =>
        {
            var equaledMagic = magicPatternLoader.Equaled(new MagicPatterns().SetList(enterHolder.lines));
            if (equaledMagic != null)
            {
                subject.OnNext(equaledMagic);
            }
        }
        );
    }
}
