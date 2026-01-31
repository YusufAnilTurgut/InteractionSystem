// 1. System namespaces
using System;

// 2. Unity namespaces
using UnityEngine;

// 4. Project namespaces
using Project.Runtime.Player;

namespace Project.Runtime.UI
{
    public sealed class HoldProgressBarUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private InteractionDetector m_Detector;

        [Header("UI References")]
        [SerializeField] private RectTransform m_BackgroundRect;
        [SerializeField] private RectTransform m_FillRect;

        [Header("Visibility")]
        [SerializeField] private GameObject m_Root;

        private float m_FullWidth;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_Detector == null)
            {
                Debug.LogError("InteractionDetector reference is missing.");
                enabled = false;
                return;
            }

            if (m_BackgroundRect == null || m_FillRect == null)
            {
                Debug.LogError("BackgroundRect or FillRect is missing.");
                enabled = false;
                return;
            }

            if (m_Root == null)
            {
                m_Root = gameObject;
            }

            m_FullWidth = m_BackgroundRect.rect.width;

            SetVisible(false);
            SetProgress(0f);
        }

        private void OnEnable()
        {
            m_Detector.OnHoldProgressChanged += OnHoldProgressChanged;
        }

        private void OnDisable()
        {
            m_Detector.OnHoldProgressChanged -= OnHoldProgressChanged;
        }

        #endregion

        #region Methods

        private void OnHoldProgressChanged(float progress)
        {
            progress = Mathf.Clamp01(progress);

            if (progress <= 0.001f)
            {
                SetProgress(0f);
                SetVisible(false);
                return;
            }

            SetVisible(true);
            SetProgress(progress);
        }

        private void SetProgress(float progress)
        {
            float width = m_FullWidth * Mathf.Clamp01(progress);

            Vector2 size = m_FillRect.sizeDelta;
            size.x = width;
            m_FillRect.sizeDelta = size;
        }

        private void SetVisible(bool visible)
        {
            m_Root.SetActive(visible);
        }

        #endregion
    }
}
