using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GenerateTrailsByPointer : MonoBehaviour {

    public OnPointerClickingEnterHolder onPointerClickingEnterHolder;
    public ParticleGenerator particleGenerator;

	// Use this for initialization
	void Start () {
        onPointerClickingEnterHolder.addedLinePosition.Subscribe(lineByVector3 => {
            particleGenerator.Generate(lineByVector3.V1, lineByVector3.V2);
        } );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
