using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject targetOfPlayer;
    // Start is called before the first frame update
    void Start()
    {
        targetOfPlayer = Camera.main.GetComponent<MainCamera>().currentPlayer;
    }

}
