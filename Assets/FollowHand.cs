using UnityEngine;

public class FollowHand : MonoBehaviour
{
    public Transform followed;
    public Vector3 offsetRotation;
    void Update()
    {
        transform.position = new Vector3(followed.position.x, followed.position.y,
        followed.position.z);
        transform.rotation = followed.rotation * Quaternion.Euler(offsetRotation.x,
        offsetRotation.y, offsetRotation.z);
    }
}
