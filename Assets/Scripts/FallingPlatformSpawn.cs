using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CurrentWorld
{
    both = 0,
    real = 1,
    fict = 2
}

public class FallingPlatformSpawn : MonoBehaviour
{

    

    const int BOTHWORLD = 0;
    const int REALWORLD = 1;
    const int TALEWORLD = 2;
    // Start is called before the first frame update
    [SerializeField]
    public bool SpawnPlatformFromStart = true;
    [Range(1.0f, 200)]
    public float respawnTime;

    [Header("Information sur le prefab")]
    [SerializeField]
    public GameObject MyPrefab;
    [SerializeField]
    public Sprite sprite;
    [Range(0.1f, 10)]
    public float TimeBeforeFall = 5.0f;
    [Range(0.1f, 10)]
    public float DestroyTime = 0.5f;
    [SerializeField]
    public CurrentWorld PlatformWorld = CurrentWorld.both;
    

    public bool IsPlatformAlive;
    
    void Start()
    {
        
        if (SpawnPlatformFromStart)
            SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlatformAlive)
        {
            StartCoroutine(WaitForSpawn());
        }
    }

    private void SpawnPlatform()
    {
        MyPrefab.GetComponent<FallingPlatform>().TimeBeforeFall = TimeBeforeFall;
        MyPrefab.GetComponent<FallingPlatform>().DestroyTime = DestroyTime;
        MyPrefab.GetComponent<FallingPlatform>().Spawner = gameObject;
        MyPrefab.GetComponent<FallingPlatform>().WorldVisibility = PlatformWorld;
        MyPrefab.GetComponent<SpriteRenderer>().sprite = sprite;
        Instantiate(MyPrefab,gameObject.transform.position,gameObject.transform.rotation, gameObject.transform);
        IsPlatformAlive = true;
    }

    IEnumerator WaitForSpawn()
    {
        IsPlatformAlive = true;
        yield return new WaitForSecondsRealtime(respawnTime);
        SpawnPlatform();
    }
}
