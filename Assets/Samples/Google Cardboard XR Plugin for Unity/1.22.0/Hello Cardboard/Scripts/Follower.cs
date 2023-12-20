using System.Collections;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5f;
    float distanceTraveled;
    private bool isReady = false;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);

        if (isReady)
        {
            StartCoroutine(TravelOne());
            isReady = false;
        }
    }

    private IEnumerator TravelOne()
    {
        float originalSpeed = speed;
        speed = 3f; // Set kecepatan tetap ke 3
        yield return new WaitForSeconds(3);

        // speed = 1;
        // yield return new WaitForSeconds(2);

        // speed = 3;
        // yield return new WaitForSeconds(5);

        // speed = 1;
        // yield return new WaitForSeconds(3);

        // speed = 0;
        // yield return new WaitForSeconds(3);

        speed = originalSpeed; // Kembalikan kecepatan ke nilai semula
        isReady = true;
    }
}
