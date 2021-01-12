using UnityEngine;
using UnityEngine.UI;

public class SkillButtonScript : MonoBehaviour
{
    public Image cdMask;
    private float _cdTime;
    public float cdTime 
    {
        get { return _cdTime; }
        set 
        {
            _cdTime = value;
            cdMask.fillAmount = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cdMask.fillAmount > 0)
            cdMask.fillAmount -= 1 / cdTime * Time.deltaTime;
    }
}
