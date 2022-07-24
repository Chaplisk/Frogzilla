// GENERATED AUTOMATICALLY FROM 'Assets/Logic/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""81760e99-d2ee-469a-a3f8-ddedd111f153"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""54b74ae0-6648-46ae-9d88-2e7064611369"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f5490c12-7f5d-481f-b9f7-19310bf8153d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3b416c20-bf40-416b-aa31-5094e69a95e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ae06a583-6635-4e71-abc0-8c5835a3c9a4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6a71123e-043a-4cad-8557-a99180810b1e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9194a222-ea0f-46ae-8f22-a8da8d81a605"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d63e153f-9e72-4422-b23a-f816697a6507"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65275c21-cfec-4df3-85ac-be14539e259a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_HorizontalMovement = m_General.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_General_Fire = m_General.FindAction("Fire", throwIfNotFound: true);
        m_General_Jump = m_General.FindAction("Jump", throwIfNotFound: true);
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

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_HorizontalMovement;
    private readonly InputAction m_General_Fire;
    private readonly InputAction m_General_Jump;
    public struct GeneralActions
    {
        private @Controls m_Wrapper;
        public GeneralActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_General_HorizontalMovement;
        public InputAction @Fire => m_Wrapper.m_General_Fire;
        public InputAction @Jump => m_Wrapper.m_General_Jump;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHorizontalMovement;
                @Fire.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnFire;
                @Jump.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    public interface IGeneralActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
