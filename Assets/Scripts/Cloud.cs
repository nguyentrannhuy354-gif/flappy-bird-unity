using UnityEngine;

public class Cloud : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.left * 3f * Time.deltaTime;

        if (transform.position.x < -10f)
            Destroy(gameObject);
    }
}
