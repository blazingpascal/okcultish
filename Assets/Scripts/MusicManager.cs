using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private static MusicManager instance = null;
    public static MusicManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this
            || GetComponent<AudioSource>().clip == instance.GetComponent<AudioSource>().clip)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
