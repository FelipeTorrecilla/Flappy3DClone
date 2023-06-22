using UnityEngine;

public class FlappyBirdPipeManager : MonoBehaviour
{
    public GameObject[] pipePrefabs;
    public float pipeSpawnInterval = 2f;
    public float pipeSpeed = 2f;
    public float pipeSpawnHeight = 2f;

    private float pipeSpawnTimer = 0f;

    void Update()
    {
        pipeSpawnTimer += Time.deltaTime;

        if (pipeSpawnTimer >= pipeSpawnInterval)
        {
            pipeSpawnTimer = 0f;

            int pipeIndex = Random.Range(0, pipePrefabs.Length);
            GameObject newPipe = Instantiate(pipePrefabs[pipeIndex], transform.position + Vector3.up * Random.Range(-pipeSpawnHeight, pipeSpawnHeight), Quaternion.identity);

            newPipe.GetComponent<Rigidbody>().velocity = Vector3.left * pipeSpeed;
            Destroy(newPipe, 10f);
        }
    }
}
