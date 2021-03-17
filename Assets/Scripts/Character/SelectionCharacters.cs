// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Character/InputGive.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputGive : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputGive()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputGive"",
    ""maps"": [
        {
            ""name"": ""SelectionCharacter"",
            ""id"": ""84bc661f-6e29-41b7-82e0-3b053f8cb409"",
            ""actions"": [
                {
                    ""name"": ""ButtonStart"",
                    ""type"": ""Button"",
                    ""id"": ""a7acdef4-1038-48cd-b76f-83f8446fc40a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""b56074e5-bcca-4b53-b363-a7ed72ad7109"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c87e3e56-f038-479d-a1db-5196b35d3475"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba11ebc7-af30-4776-8725-d6a101217403"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SelectionCharacter
        m_SelectionCharacter = asset.FindActionMap("SelectionCharacter", throwIfNotFound: true);
        m_SelectionCharacter_ButtonStart = m_SelectionCharacter.FindAction("ButtonStart", throwIfNotFound: true);
        m_SelectionCharacter_Movement = m_SelectionCharacter.FindAction("Movement", throwIfNotFound: true);
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

    // SelectionCharacter
    private readonly InputActionMap m_SelectionCharacter;
    private ISelectionCharacterActions m_SelectionCharacterActionsCallbackInterface;
    private readonly InputAction m_SelectionCharacter_ButtonStart;
    private readonly InputAction m_SelectionCharacter_Movement;
    public struct SelectionCharacterActions
    {
        private @InputGive m_Wrapper;
        public SelectionCharacterActions(@InputGive wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonStart => m_Wrapper.m_SelectionCharacter_ButtonStart;
        public InputAction @Movement => m_Wrapper.m_SelectionCharacter_Movement;
        public InputActionMap Get() { return m_Wrapper.m_SelectionCharacter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionCharacterActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionCharacterActions instance)
        {
            if (m_Wrapper.m_SelectionCharacterActionsCallbackInterface != null)
            {
                @ButtonStart.started -= m_Wrapper.m_SelectionCharacterActionsCallbackInterface.OnButtonStart;
                @ButtonStart.performed -= m_Wrapper.m_SelectionCharacterActionsCallbackInterface.OnButtonStart;
                @ButtonStart.canceled -= m_Wrapper.m_SelectionCharacterActionsCallbackInterface.OnButtonStart;
                @Movement.started -= m_Wrapper.m_SelectionCharacterActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SelectionCharacterActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SelectionCharacterActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_SelectionCharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ButtonStart.started += instance.OnButtonStart;
                @ButtonStart.performed += instance.OnButtonStart;
                @ButtonStart.canceled += instance.OnButtonStart;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public SelectionCharacterActions @SelectionCharacter => new SelectionCharacterActions(this);
    public interface ISelectionCharacterActions
    {
        void OnButtonStart(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
