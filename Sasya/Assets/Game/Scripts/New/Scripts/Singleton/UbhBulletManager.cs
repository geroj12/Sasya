﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager of UbhBullet
/// </summary>
[DisallowMultipleComponent]
public sealed class UbhBulletManager : UbhSingletonMonoBehavior<UbhBulletManager>
{
    private List<Bullet> m_bulletList = new List<Bullet>(2048);
    private HashSet<Bullet> m_bulletHashSet = new HashSet<Bullet>();

    public int activeBulletCount { get { return m_bulletList.Count; } }

    protected override void DoAwake()
    {
        // Create UbhTimer
        if (UbhTimer.instance == null) { }
    }

    /// <summary>
    /// Update Bullets Move
    /// </summary>
    public void UpdateBullets(float deltaTime)
    {
        for (int i = m_bulletList.Count - 1; i >= 0; i--)
        {
            Bullet bullet = m_bulletList[i];
            if (bullet == null)
            {
                m_bulletList.Remove(bullet);
                continue;
            }
            bullet.UpdateMove(deltaTime);
        }
    }

    /// <summary>
    /// Add bullet
    /// </summary>
    public void AddBullet(Bullet bullet)
    {
        if (m_bulletHashSet.Contains(bullet))
        {
            UbhDebugLog.LogWarning(bullet.name + " This bullet is already added in m_bulletList.", bullet);
            return;
        }
        m_bulletList.Add(bullet);
        m_bulletHashSet.Add(bullet);
    }

    /// <summary>
    /// Remove bullet
    /// </summary>
    public void RemoveBullet(Bullet bullet, bool destroy)
    {
        if (m_bulletHashSet.Contains(bullet) == false)
        {
            UbhDebugLog.LogWarning(bullet.name + " This bullet is not found in m_bulletList.", bullet);
            bullet.reserveReleaseOnShot = true;
            bullet.reserveReleaseOnShotIsDestroy = destroy;
            return;
        }
        m_bulletList.Remove(bullet);
        m_bulletHashSet.Remove(bullet);
    }
}
