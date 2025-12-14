using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SMP_LIG
{
    public class RainbowText : MonoBehaviour
    {
        [SerializeField] private Gradient colorGrad;
        private TextMeshProUGUI TMPG;

        void Start()
        {
            TMPG = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            TMPG.color = colorGrad.Evaluate(Mathf.PingPong(Time.time, 1));
        }
    }
}
