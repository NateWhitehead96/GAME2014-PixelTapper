using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText = null;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives : " + SwipeControls.lives;
    }
}
