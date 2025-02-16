using UnityEngine;

public class Destroysoundeffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,1);//this gameobject will be destroyed after 1 sec.
    }
}
