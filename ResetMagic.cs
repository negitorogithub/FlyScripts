using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMagic : MonoBehaviour {

    OnPointerClickingEnterHolder enterHolder;
    GenerateTrailsByPointer generateTrails;
    GenerateMagicParticle generateMagic;

	// Use this for initialization
	void Start () {
		
	}

    public void Reset()
    {
        enterHolder.ResetExists();
        generateTrails.DeleteTrails();
        generateMagic.DeleteAllParticles();
    }

}
