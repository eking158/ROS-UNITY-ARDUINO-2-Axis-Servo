using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class teleoperation : MonoBehaviour
{

    public Transform servo_1, servo_2;
    float m_fSpeed = 0.4f;

    
    void Start()
    {
        
    }
 
    void Update()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        servo_1.Rotate(new Vector3(0, 1 , 0) *m_fSpeed*fHorizontal);
        servo_2.Rotate(new Vector3(0 ,0 , 1) * m_fSpeed*fVertical);
 
        //servo_1.Rotate(Vector3.up * Time.deltaTime * m_fSpeed * fHorizontal, Space.World);
        //servo_2.Rotate(Vector3.up  * Time.deltaTime * m_fSpeed * fVertical, Space.World);
    }
}
 
