using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Larry Xu
public interface IEnemy
{
    void fire();
    void move();
    void OnDamage(int damage);
    void die();
}
