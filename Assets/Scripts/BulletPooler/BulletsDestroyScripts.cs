﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsDestroyScripts : MonoBehaviour
{
    private void OnEnable() {
        Invoke("Destroy", 2f);
    }

    private void Destroy() {
        gameObject.SetActive(false);
    }
    private void OnDisable() {
        CancelInvoke();
    }
}
