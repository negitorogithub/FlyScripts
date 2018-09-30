using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResetMagic : MonoBehaviour {

     public OnPointerClickingEnterHolder enterHolder;
     public GenerateTrailsByPointer generateTrails;
     public GenerateMagicParticle generateMagic;
     public SendMagicSummoned sendMagicSummoned;

	// Use this for initialization
	void Start () {
        sendMagicSummoned.subject.Delay(System.TimeSpan.FromSeconds(2f)).Subscribe(_ => Reset());
	}

    public void Reset()
    {
        enterHolder.ResetExists();
        generateTrails.DeleteTrails();
        generateMagic.DeleteAllParticles();
    }

}
