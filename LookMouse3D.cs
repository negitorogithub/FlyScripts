using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse3D : MonoBehaviour {

    private Transform transformParent;
    private Transform transformChild;
    public float sensitivity;
    
	void Start () {
        transformParent = transform.parent;
        transformChild = transform;
    }

    // Update is called once per frame
    void LateUpdate () {
        transformParent = transform.parent;
        transformChild = transform;
        float X_Rotation = Input.GetAxis("Mouse X") * sensitivity;
        float Y_Rotation = Input.GetAxis("Mouse Y") * sensitivity;

        transformParent.RotateAround(transformChild.position, transformParent.up ,X_Rotation);
        transformChild.RotateAround(transformChild.position, transformChild.right ,-Y_Rotation);
        
	}
}
