using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIk : MonoBehaviour
{
    public Transform target, joint_1, joint_2, joint_3, joint_4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float px=(float)target.transform.position.x;
        float py=(float)target.transform.position.y;
        float pz=(float)target.transform.position.z;

        float L1=(float)Vector3.Distance(joint_1.transform.position,joint_2.transform.position);  //d1
        float L2=(float)Vector3.Distance(joint_2.transform.position,joint_3.transform.position);  //a1
        float L3=(float)Vector3.Distance(joint_3.transform.position,joint_4.transform.position);  //a2
        //Debug.Log("px: "+px+" "+ "py: " + py + " " + "pz: " + pz + " ");

        float s2=(py-L1)/L3;
        float c2=Mathf.Sqrt(1-s2*s2);

        float theta2=Mathf.Atan2(s2,c2)*Mathf.Rad2Deg+0;
        float theta1=Mathf.Atan2(pz,-px)*Mathf.Rad2Deg+0;
        //Debug.Log("L1: "+L1+" "+ "L2: " + L2 + " " + "L3: " + L3 + " ");
        Debug.Log("theta 1: "+theta1+" "+ "theta 2: " + theta2 );

        if (!float.IsNaN(theta1))
            joint_1.transform.localEulerAngles = new Vector3(180, theta1,0);
        if (!float.IsNaN(theta2))
            joint_3.transform.localEulerAngles = new Vector3(180, 0, -theta2);
    }

    float map(float x, float in_min, float in_max, float out_min, float out_max) {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
}
}
