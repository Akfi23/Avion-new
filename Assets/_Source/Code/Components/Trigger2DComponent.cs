using _Source.Code.Signals;
using UnityEngine;

namespace _Source.Code.Components
{
   public class Trigger2DComponent : MonoBehaviour
   {
      private OnTriggerEnter2DSignal _enterSignal;
      private OnTriggerExit2DSignal _exitSignal;

      public void Awake()
      {
         _enterSignal = Supyrb.Signals.Get<OnTriggerEnter2DSignal>();
         _exitSignal = Supyrb.Signals.Get<OnTriggerExit2DSignal>();
      }

      public void OnTriggerEnter2D(Collider2D other)
      {
         _enterSignal.Dispatch(transform,other.transform);
      }

      public void OnTriggerExit2D(Collider2D other)
      {
         _exitSignal.Dispatch(transform,other.transform);
      }
   }
}
