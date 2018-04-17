using UnityEngine;
using System.Collections;

/// <summary>
/// 在磁场内的小磁针受磁力影响
/// </summary>
public class MagneticField : MonoBehaviour
{
    //磁铁的南北极
    public GameObject NP;
    public GameObject SP;

    //磁常数项
    private float mu0 = 10.0f;

    //磁力强度
    public float strength;

    //-----------------------------------------------------------------------

    void OnTriggerStay(Collider other)
    {
        //如果小磁针的N极在磁场范围内
        if (other.gameObject.tag == "MagnetNeedleN")
        {
            //得到父物体的刚体
            Rigidbody other_rb = other.gameObject.transform.parent.GetComponent<Rigidbody>();

            //小磁针的N极和条形磁铁两极的距离
            Vector3 r_n = other.gameObject.transform.position + new Vector3(0, 0, 0.25f) - NP.transform.position;

            //计算磁力
            float mu = Time.fixedDeltaTime * strength * mu0 * other_rb.mass;

            //根据公式计算实际磁力大小
            Vector3 f_n = (r_n.normalized) * mu / (Mathf.Pow(Mathf.Max(r_n.magnitude, 0.2f), 3));

            //给小磁针的N极位置一个定点力，当做磁力
            other_rb.AddForceAtPosition(1f * f_n, other.transform.position);
        }
        else if (other.gameObject.tag == "MagnetNeedleS")
        {
            Rigidbody other_rb = other.gameObject.transform.parent.GetComponent<Rigidbody>();

            Vector3 r_s = other.gameObject.transform.position + new Vector3(0, 0, -0.25f) - SP.transform.position;

            float mu = Time.fixedDeltaTime * strength * mu0 * other_rb.mass;

            Vector3 f_s = (r_s.normalized) * mu / (Mathf.Pow(Mathf.Max(r_s.magnitude, 0.2f), 3));

            other_rb.AddForceAtPosition(1f * f_s, other.transform.position);
        }
    }

    //-----------------------------------------------------------------------
}
