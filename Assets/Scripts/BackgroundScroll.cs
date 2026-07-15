using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 0.1f;
    public float loopDistance = 20f;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.localPosition.x <= startPos.x - loopDistance)
        {
            transform.localPosition = startPos;
        }
    }
}
