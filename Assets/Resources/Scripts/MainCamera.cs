using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject target;    
    void Update()
    {
        this.transform.position = new Vector3(target.transform.position.x, -1.9f, -10);
    }
}
