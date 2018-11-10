using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColidingObjectHolder : MonoBehaviour
{
    public ICollection<GameObject> gameObjects;

    // Use this for initialization
    void Start()
    {
        gameObjects = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        gameObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        gameObjects.Remove(other.gameObject);
    }
}
