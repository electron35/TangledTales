using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformSpawn : MonoBehaviour
{
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

    

    public bool IsPlatformAlive;
    
    void Start()
    {
        MyPrefab.GetComponent<FallingPlatform>().TimeBeforeFall = TimeBeforeFall;
        MyPrefab.GetComponent<FallingPlatform>().DestroyTime = DestroyTime;
        MyPrefab.GetComponent<FallingPlatform>().Spawner = gameObject;
        MyPrefab.GetComponent<SpriteRenderer>().sprite = sprite;
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
        Instantiate(MyPrefab,gameObject.transform.position,gameObject.transform.rotation);
        IsPlatformAlive = true;
    }

    IEnumerator WaitForSpawn()
    {
        IsPlatformAlive = true;
        yield return new WaitForSecondsRealtime(respawnTime);
        SpawnPlatform();
    }
}
