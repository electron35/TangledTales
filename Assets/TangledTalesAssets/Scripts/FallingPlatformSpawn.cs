using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public bool SpawnPlatformFromStart = true;
    [SerializeField]
    public GameObject MyPrefab;

    [Range(1.0f, 200)]
    public float respawnTime;

    public bool IsPlatformAlive;
    
    void Start()
    {
        MyPrefab.GetComponent<FallingPlatform>().Spawner = gameObject;
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
        Instantiate(MyPrefab);
        IsPlatformAlive = true;
    }

    IEnumerator WaitForSpawn()
    {
        IsPlatformAlive = true;
        yield return new WaitForSecondsRealtime(respawnTime);
        SpawnPlatform();
    }
}
