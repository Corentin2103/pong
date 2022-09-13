using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float intensity = 0.5f;
    public float ticks = 5f;
    public float waitTimeBetweenTicks = 0.1f;

    public void GoalShake()
    {
        StartCoroutine(Shake(intensity, ticks));
    }

    IEnumerator Shake(float intensity, float ticks)
    {
        Vector3 origin = transform.position;

        for(int i = 0; i < ticks; i++)
        {
            Vector3 offsetPosition = new Vector3(
                Random.Range(-1f, 1f) * intensity, 
                Random.Range(-1f, 1f) * intensity, 
                origin.z);

            transform.position = intensity * offsetPosition;
            yield return new WaitForSeconds(waitTimeBetweenTicks);
        }

        transform.position = origin;
    }
}
