using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseLayout : MonoBehaviour
{
    public void Open(GameObject opendLayout)
    {
        Switch(opendLayout, true);
    }

    public void Close(GameObject closedLayout)
    {
        Switch(closedLayout, false);
    }

    private void Switch(GameObject gameObject, bool value)
    {
        gameObject.SetActive(value);
    }
}
