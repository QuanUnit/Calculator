using UnityEngine;

namespace UI.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);

        public virtual void Hide() => gameObject.SetActive(false);
    }
}