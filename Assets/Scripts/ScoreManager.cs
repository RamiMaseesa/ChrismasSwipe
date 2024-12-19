using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text text;
    public float score = 0;

    void Update() {
        text.text = score.ToString();
    }
}
