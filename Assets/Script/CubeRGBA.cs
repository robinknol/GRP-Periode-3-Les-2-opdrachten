using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRGBA : MonoBehaviour
{
    public float fadeTime;
    Material material;
    bool onePress = false;
    bool isVisible;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        if (material.color.a == 0)
        {
            isVisible = false;
        }
        else
        {
            isVisible = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onePress == false)
            {
                onePress = true;
                StartCoroutine("Fade");
            }
        }
    }

    IEnumerator Fade()
    {
        if (isVisible == true)
        {
            for (float i = material.color.a; i > 0f; i -= 0.1f)
            {
                material.color = new Color(1f, 1f, 1f, i);
                print(i);
                yield return new WaitForSeconds(fadeTime);
            }
            material.color = new Color(1f, 1f, 1f, 0f);
            isVisible = false;
        }
        else if (isVisible == false)
        {
            for (float i = material.color.a; i < 1f; i += 0.1f)
            {
                material.color = new Color(1f, 1f, 1f, i);
                print(i);
                yield return new WaitForSeconds(fadeTime);
            }
            material.color = new Color(1f, 1f, 1f, 1f);
            isVisible = true;
        }
        onePress = false;
    }
}
