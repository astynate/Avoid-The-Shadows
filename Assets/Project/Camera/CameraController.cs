using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody followingPerson = null!;

    public Vector3 offset = Vector3.zero;

    void FixedUpdate()
    {
        transform.position = followingPerson.position + offset;
    }
}