using UnityEngine;

public class backgroundmusic : MonoBehaviour
{
    private static backgroundmusic backmusic;

    void Awake()
    {
        if(backmusic == null)
        {
            backmusic = this;
            DontDestroyOnLoad(backmusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
