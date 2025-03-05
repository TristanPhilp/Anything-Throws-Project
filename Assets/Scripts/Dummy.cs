//help with actions:
//https://learn.microsoft.com/en-us/dotnet/api/system.action-1
using UnityEngine;

namespace EmmyExperimental {
    public class Dummy : MonoBehaviour {
        System.Action callToAction;
        System.Action<float> callToActionFloat;

        void Start()
        {
            callToAction += OnCallToAction;
            callToActionFloat += OnCallToActionFloat;
        }

        void Trigger() {
            callToAction?.Invoke();
        }

          void TriggerFloat(float f) {
            callToActionFloat?.Invoke(f);
        }


        void OnCallToAction() {
        }

        void OnCallToActionFloat (float f) {
        }
    }
}