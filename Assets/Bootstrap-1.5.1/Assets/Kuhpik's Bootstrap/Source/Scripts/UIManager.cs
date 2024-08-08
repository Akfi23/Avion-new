using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Kuhpik
{
    public class UIManager : MonoBehaviour
    {
        static Dictionary<Type, UIScreen> uiScreensByType;
        static UIScreen[] uiScreens;

        public TMP_FontAsset font;

        [Button]
        public void ChangeFonts()
        {
            foreach (var text in GetComponentsInChildren<TMP_Text>())
            {
                text.font = font;
            }
        }
        
        void Start()
        {
            uiScreens = FindObjectsOfType<UIScreen>();
            uiScreensByType = uiScreens.Where(x => x.GetType() != typeof(UIScreen)).ToDictionary(x => x.GetType(), x => x);

            foreach (var screen in uiScreensByType.Values)
            {
                Bootstrap.Instance.itemsToInject.Add(screen);
                screen.Subscribe();
            }

            Bootstrap.Instance.StateEnterEvent += TryOpenScreenWithState;
            Bootstrap.Instance.StateExitEvent += x => CloseAllScreens();

            CloseAllScreens();
        }

        public static void OpenScreen<T>(Type type) where T : UIScreen
        {
            if (uiScreensByType.ContainsKey(type))
            {
                uiScreensByType[type].Open();
            }
        }

        public static void CloseScreen<T>(Type type) where T : UIScreen
        {
            if (uiScreensByType.ContainsKey(type))
            {
                uiScreensByType[type].Close();
            }
        }

        public static void CloseAllScreens()
        {
            foreach (var screen in uiScreens)
            {
                screen.Close();
            }
        }

        public static T GetUIScreen<T>() where T : UIScreen
        {
            return uiScreensByType[typeof(T)] as T;
        }

        void TryOpenScreenWithState(GameStateID id)
        {
            foreach (var screen in uiScreens)
            {
                screen.TryOpenWithState(id);
            }
        }
    }
}