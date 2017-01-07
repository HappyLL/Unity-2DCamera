using UnityEngine;
using System.Collections;

public class FollowBehavior : MonoBehaviour {

    public Transform trackingTarget;
    public float offsetX = 5.0f;
    public float offsetY = 4.0f;
    public float followSpeed = 1.0f;

    public bool isXLocked = false;
    public bool isYLocked = false;
	// Use this for initialization
	void Start () {
        //m_offset = transform.position - trackingTarget.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //transform.position = trackingTarget.position + m_offset;
        float newX = transform.position.x;
        float targetX = trackingTarget.position.x + offsetX;
        if (!isXLocked)
        {
            newX = Mathf.Lerp(newX, targetX, Time.deltaTime * followSpeed);
        }
        float newY = transform.position.y;
        float targetY = trackingTarget.position.y + offsetY;
        if (!isYLocked)
        {
            newY = Mathf.Lerp(newY, targetY, Time.deltaTime * followSpeed);
        }
        transform.position = new Vector3(newX , newY , transform.position.z);
    }
}
