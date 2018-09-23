using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmParticleSystem : MonoBehaviour {


    new private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();

        particleSystem.Simulate(0f);
        particleSystem.Emit(1);
        particleSystem.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
