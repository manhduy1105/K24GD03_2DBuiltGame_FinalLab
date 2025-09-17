using Unity.VisualScripting;
using UnityEngine;

public class Dontdest : MonoBehaviour
{
    private static Dontdest instance;

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
