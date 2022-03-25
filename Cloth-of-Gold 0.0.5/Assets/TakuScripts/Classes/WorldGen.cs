using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class WorldGen : ScriptableObject, IWorldTransformable {
	public abstract void doWorldTransform();
}
