using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private Transform igrok;
    private void Update()
    {
        transform.position = new Vector3(igrok.position.x, igrok.position.y, transform.position.z);
    }
}
