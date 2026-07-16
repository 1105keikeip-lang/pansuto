using UnityEngine;

public class PunchLogoAnimation : MonoBehaviour
{
    public float startDistance = 10f;
    public float punchScale = 1.3f;
    public float punchSpeed = 5f;
    public float returnSpeed = 2f;
    public float delay = 2f;

    Vector3 originalPos;
    Vector3 originalScale;
    bool isPunching = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.localPosition;
        originalScale = transform.localScale;
        InvokeRepeating(nameof(StartPunch), delay, delay);
    }


    void StartPunch()
    {
        if (!isPunching)
            StartCoroutine(PunchRoutine());
    }

    System.Collections.IEnumerator PunchRoutine()
    {
        isPunching = true;

        transform.localPosition = originalPos + new Vector3(0, 0, -startDistance);
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * punchSpeed;
            transform.localPosition = Vector3.Lerp(originalPos + new Vector3(0, 0, -startDistance), originalPos, t);
            yield return null;
        }

        // ƒpƒ“ƒ`iŠg‘å{Œy‚¢‰ñ“]j
        transform.localScale = originalScale * punchScale;
        transform.Rotate(Vector3.forward * Random.Range(-10f, 10f));
        yield return new WaitForSeconds(0.1f);

        // –ß‚é
        transform.localScale = originalScale;
        transform.localRotation = Quaternion.identity;
        yield return new WaitForSeconds(returnSpeed);

        isPunching = false;
    }
    // Update is called once per frame
   
}
