using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingNums : MonoBehaviour
{
    public GameObject floatingObject;
    public TMP_Text floatngText;

    void update ()
    {
        floatngText = "+ " + hitPower; /// click power goes here
    }

    private void clicked()
    {
        floatingObject.SetActive(false);

        floatingObject.transform.position = new Vector3(Random.Range(400, 550 + 1), Random.Range(160, 360 + 1), 0); /// random spot around clickable object

        floatingObject.SetActive(true);

        StopAllCoroutines();

        StartCoroutine(Fly());
    }

    IEnumerator Fly()  /// makes numbers fly UP
    {
        for(int i = 0; i  <= 19; i++)
        {
            yield return new WaitForSeconds(0.01f);

            floatingObject.transform.position = new Vector3(floatingObject.transform.position.x, floatingObject.transform.position.y + 2, 0);
        }

        floatingObject.SetActive(false);
    }
}
