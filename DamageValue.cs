using System.Collections;
using UnityEngine;

namespace DamageValues
{
    internal class DamageValue : MonoBehaviour
    {
        private SpriteRenderer[] _renderers;
        private Rigidbody2D _rb;
        private void Awake()
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.isKinematic = true;
            _renderers = GetComponentsInChildren<SpriteRenderer>();
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float opacity = 1.0f;
            float fadeRate = 2;
            _rb.velocity = Vector2.up * 2.5f;
            yield return new WaitUntil(() =>
            {
                Color c = (NailSlash.Reflection.fury ? new Color(1, 0.7, 0.7, opacity) : new Color(1, 1, 1, opacity));
                foreach (SpriteRenderer rend in _renderers)
                    rend.color = c;
                opacity -= Time.deltaTime * fadeRate;
                return opacity <= 0;
            });
            Destroy(gameObject);
        }
    }
    
    internal class TickValue : MonoBehaviour
    {
        private SpriteRenderer[] _renderers;
        private Rigidbody2D _rb;
        private void Awake()
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.isKinematic = true;
            _renderers = GetComponentsInChildren<SpriteRenderer>();
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float opacity = 1.0f;
            float fadeRate = 2;
            _rb.velocity = Vector2.up * 2.5f;
            yield return new WaitUntil(() =>
            {
                foreach (SpriteRenderer rend in _renderers)
                    rend.color = new Color(1, 1, 0.3, opacity);
                opacity -= Time.deltaTime * fadeRate;
                return opacity <= 0;
            });
            Destroy(gameObject);
        }
    }
}
