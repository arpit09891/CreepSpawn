using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogButton : MonoBehaviour {

    public RectTransform UICanvas;
	public void ToggleButton()
    {
        if (UICanvas.gameObject.activeSelf)
            UICanvas.gameObject.SetActive(false);

        else
            UICanvas.gameObject.SetActive(true);
    }
}
