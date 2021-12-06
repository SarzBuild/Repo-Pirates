using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class DoTweenDissapearOverTime : MonoBehaviour
{
    [SerializeField] public float Seconds;
    [SerializeField] [Range(0, 1)] public float AlphaValueAtEnd;
    [SerializeField] public Ease Ease;
    
    private void OnEnable() => transform.GetComponentInChildren<TMP_Text>().DOFade(AlphaValueAtEnd, Seconds).SetEase(Ease);
}
