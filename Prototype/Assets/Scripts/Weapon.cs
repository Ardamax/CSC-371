﻿using UnityEngine;
using System.Collections;

//This is a basic interface with a single required
//method.
public interface IWeapon
{
    void fire();
    void stopFiring();
}