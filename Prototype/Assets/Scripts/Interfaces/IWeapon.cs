using UnityEngine;
using System.Collections;

//Main Author: Larry Xu
public interface IWeapon
{
    void fire();
    void stopFiring();
    string toString();
}
