using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Printing");
        }
    }

    IEnumerator Printing()
    {
        print("I am starting the coroutine");

        yield return new WaitForSeconds(0.5f);

        for (int i = 1; i <= 10; i++)
        { 
            print("coroutine update" + " " + i);
        }

        yield return new WaitForSeconds(0.5f);

        print("coroutine end");
    }
}
