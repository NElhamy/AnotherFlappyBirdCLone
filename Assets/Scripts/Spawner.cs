using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating("Spawn", Random.Range(spawnRate, spawnRate + 0.2f), Random.Range(spawnRate, spawnRate + 0.2f));
    }

    private void FixedUpdate()
    {
        //&*^&^&%^U$*
        if ((FindObjectOfType<GameManager>().GetScore() + 1) % 10 == 0)
        {
            spawnRate -= 0.2f;
            Debug.Log("Speed increased");

        }
    }

    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
