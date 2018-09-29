using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour {

    public new ParticleSystem particleSystem;
    private GameObject parent;


    public void Start()
    {
        parent = new GameObject();
    }

    // Update is called once per frame
    public void Generate (Vector3 startPosition, Vector3 endPosition) {
        var particleSystem2Gen = particleSystem;
        particleSystem2Gen.gameObject.SetActive(true);
        particleSystem2Gen.transform.position = startPosition;
        Vector3 rotationOffset = particleSystem2Gen.shape.rotation;
        particleSystem2Gen.transform.forward = (endPosition - startPosition - rotationOffset).normalized;
        var main = particleSystem2Gen.main;
        main.startLifetime = new ParticleSystem.MinMaxCurve((endPosition - startPosition).magnitude * 10 / main.startSpeed.constant);
        Instantiate(particleSystem2Gen, parent.transform);
    }

    public void DeleteAllParticles()
    {
        parent = new GameObject();
    }
}
