using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextView1 : ContextView {
    private void Awake()
    {
        this.context = new Demo1Context(this);
    }
}
