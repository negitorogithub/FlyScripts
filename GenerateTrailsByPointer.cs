using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GenerateTrailsByPointer : MonoBehaviour {

    public OnPointerClickingEnterHolder onPointerClickingEnterHolder;
    public GenerateTrails trailsGenerator;

	// Use this for initialization
	void Start () {
        onPointerClickingEnterHolder.addedLinePosition.Subscribe(lineByVector3 => {
            trailsGenerator.Generate(lineByVector3.V1, lineByVector3.V2);
        } );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeleteTrails()
    {
        trailsGenerator.DeleteAllParticles();
    }
}
