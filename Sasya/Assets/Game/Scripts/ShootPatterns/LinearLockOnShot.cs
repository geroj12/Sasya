using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Purgatory
{

    /// <summary>
    /// Ubh linear lock on shot.
    /// </summary>
    [AddComponentMenu("UniBulletHell/Shot Pattern/Linear Shot (Lock On)")]
    public class LinearLockOnShot : LinearShot
    {
        [Header("===== LinearLockOnShot Settings =====")]
        // "Set a target with tag name."
        [FormerlySerializedAs("_SetTargetFromTag")]
        public bool m_setTargetFromTag = true;
        // "Set a unique tag name of target at using SetTargetFromTag."
        [FormerlySerializedAs("_TargetTagName")]
        public string m_targetTagName = "Player";
        // "Flag to select random from GameObjects of the same tag."
        public bool m_randomSelectTagTarget;
        // "Flag to select nearest from GameObjects of the same tag."
        public bool m_nearestSelectTagTarget;
        // "Transform of lock on target."
        // "It is not necessary if you want to specify target in tag."
        // "Overwrite Angle in direction of target to Transform.position."
        [FormerlySerializedAs("_TargetTransform")]
        public Transform m_targetTransform;
        // "Always aim to target."
        [FormerlySerializedAs("_Aiming")]
        public bool m_aiming;

        /// <summary>
        /// is lock on shot flag.
        /// </summary>
        public override bool lockOnShot { get { return true; } }

        public override void Shot()
        {
            AimTarget();
            base.Shot();
        }

        public override void FinishedShot()
        {
            if (m_setTargetFromTag)
            {
                m_targetTransform = null;
            }
            base.FinishedShot();
        }

        protected override void Update()
        {
            if (m_shooting && m_aiming)
            {
                AimTarget();
            }

            base.Update();
        }

        private void AimTarget()
        {
            if (m_targetTransform == null && m_setTargetFromTag)
            {
                m_targetTransform = UbhUtil.GetTransformFromTagName(m_targetTagName, m_randomSelectTagTarget, m_nearestSelectTagTarget, transform);
            }
            if (m_targetTransform != null)
            {
                m_angle = UbhUtil.GetAngleFromTwoPosition(transform, m_targetTransform, shotCtrl.m_axisMove);
            }
        }
    }
}