//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Controls/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""f87898f2-dbcb-4180-a69f-9edee454c3bd"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9fe788f3-e82a-484c-b9f3-06a6fa008e83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""0eea2d69-cfc2-4a75-aef7-39bd917e5bb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9617a6cb-c586-48f9-a438-b6f6c3bda55a"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17384066-498a-40be-8fcb-1571f06f80ba"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Desktop"",
            ""id"": ""ff045ce6-1fe3-4c64-922c-39cd14b2ba8f"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""7d727f78-5acb-48a3-a79f-dd9f094b90a9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""3747c276-5d5c-4df7-b90f-0db0d7902961"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ffa6ae2-4510-4d4d-9c36-286e7310bc98"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""515078b3-9649-40c7-8647-d67c127b91bc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Position = m_Touch.FindAction("Position", throwIfNotFound: true);
        m_Touch_Launch = m_Touch.FindAction("Launch", throwIfNotFound: true);
        // Desktop
        m_Desktop = asset.FindActionMap("Desktop", throwIfNotFound: true);
        m_Desktop_Position = m_Desktop.FindAction("Position", throwIfNotFound: true);
        m_Desktop_Launch = m_Desktop.FindAction("Launch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private List<ITouchActions> m_TouchActionsCallbackInterfaces = new List<ITouchActions>();
    private readonly InputAction m_Touch_Position;
    private readonly InputAction m_Touch_Launch;
    public struct TouchActions
    {
        private @Controls m_Wrapper;
        public TouchActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_Touch_Position;
        public InputAction @Launch => m_Wrapper.m_Touch_Launch;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void AddCallbacks(ITouchActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchActionsCallbackInterfaces.Add(instance);
            @Position.started += instance.OnPosition;
            @Position.performed += instance.OnPosition;
            @Position.canceled += instance.OnPosition;
            @Launch.started += instance.OnLaunch;
            @Launch.performed += instance.OnLaunch;
            @Launch.canceled += instance.OnLaunch;
        }

        private void UnregisterCallbacks(ITouchActions instance)
        {
            @Position.started -= instance.OnPosition;
            @Position.performed -= instance.OnPosition;
            @Position.canceled -= instance.OnPosition;
            @Launch.started -= instance.OnLaunch;
            @Launch.performed -= instance.OnLaunch;
            @Launch.canceled -= instance.OnLaunch;
        }

        public void RemoveCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // Desktop
    private readonly InputActionMap m_Desktop;
    private List<IDesktopActions> m_DesktopActionsCallbackInterfaces = new List<IDesktopActions>();
    private readonly InputAction m_Desktop_Position;
    private readonly InputAction m_Desktop_Launch;
    public struct DesktopActions
    {
        private @Controls m_Wrapper;
        public DesktopActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_Desktop_Position;
        public InputAction @Launch => m_Wrapper.m_Desktop_Launch;
        public InputActionMap Get() { return m_Wrapper.m_Desktop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DesktopActions set) { return set.Get(); }
        public void AddCallbacks(IDesktopActions instance)
        {
            if (instance == null || m_Wrapper.m_DesktopActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DesktopActionsCallbackInterfaces.Add(instance);
            @Position.started += instance.OnPosition;
            @Position.performed += instance.OnPosition;
            @Position.canceled += instance.OnPosition;
            @Launch.started += instance.OnLaunch;
            @Launch.performed += instance.OnLaunch;
            @Launch.canceled += instance.OnLaunch;
        }

        private void UnregisterCallbacks(IDesktopActions instance)
        {
            @Position.started -= instance.OnPosition;
            @Position.performed -= instance.OnPosition;
            @Position.canceled -= instance.OnPosition;
            @Launch.started -= instance.OnLaunch;
            @Launch.performed -= instance.OnLaunch;
            @Launch.canceled -= instance.OnLaunch;
        }

        public void RemoveCallbacks(IDesktopActions instance)
        {
            if (m_Wrapper.m_DesktopActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDesktopActions instance)
        {
            foreach (var item in m_Wrapper.m_DesktopActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DesktopActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DesktopActions @Desktop => new DesktopActions(this);
    public interface ITouchActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
    }
    public interface IDesktopActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
    }
}