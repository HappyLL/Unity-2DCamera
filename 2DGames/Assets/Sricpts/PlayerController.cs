using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float m_speed = 5.0f;
    public float m_upV = 20.0f;
    public float m_initY = -2.0f;

    private float m_g = 10.0f;
    private Rigidbody m_rig;
    private bool m_bUp = false;
    private float m_v = 0f;
    private float m_goneTm = 0f;
	// Use this for initialization
	void Start () {
        m_rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * m_speed;
        //float y = Input.GetAxis("Vertical");
        float originX = m_rig.position.x;
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_bUp)
                return;
            m_v = m_upV;
            m_goneTm = 0;
            m_bUp = true;
        }
        double h = 0;
        if (m_bUp)
        {
            m_goneTm = m_goneTm + Time.deltaTime;
            h = m_v*m_goneTm - 0.5 * m_g * m_goneTm*m_goneTm;
        }
        if (h <= 0)
        {
            h = 0;
            m_bUp = false;
        }
        m_rig.position = new Vector3(Mathf.Lerp(originX, originX + x, Time.deltaTime), (float)h + m_initY, m_rig.position.z);
    }
}
