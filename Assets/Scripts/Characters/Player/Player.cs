using Survivor.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Characters.Player
{
    public class Player : MonoBehaviour
    {
        public PlayerController controller;
        public HealthComponent health;
        public WeaponManager weaponManager;
    }
}