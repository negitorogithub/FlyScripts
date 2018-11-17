using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class FreezePlayerWhenTalking : MonoBehaviour
{

    public List<GameObject> targetOfIPausable;
    private List<List<IPausable>> target;
    // Use this for initialization
    void Start()
    {
        target = targetOfIPausable.Select(obj => obj.GetComponents<IPausable>().ToList()).ToList();
        ConstantScenarioModelOfNPC.onShowText.Subscribe(_ =>
            target.ForEach(ipausableList =>
                ipausableList.ForEach(ipausable => ipausable.Pause())
            )
        );
        ConstantScenarioModelOfNPC.onEndShowing.Subscribe(_ =>
            target.ForEach(ipausableList =>
                ipausableList.ForEach(ipausable => ipausable.Resume())
            )
        );

    }
}
