using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform object_to_follow;
    public Vector3 offset ;
    // Update is called once per frame

    private void Start()
    {
        offset = new Vector2 (0, 0.40f);
        transform.SetParent(GameObject.FindAnyObjectByType<Canvas>().transform);
    }
    void Update()
    {
        transform.position = object_to_follow.position - offset;
    }
}
