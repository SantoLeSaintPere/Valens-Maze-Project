using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void OnExit();
    public abstract void InUpdate(float deltaTime);
    public abstract void InStart();
}
