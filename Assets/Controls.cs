// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""20b94de9-a483-49be-992b-bcab893f78c8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3dc5eba3-6b7f-430a-94f5-015bb7353dd0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""7304d985-2b44-4162-bdfb-d83af267e1ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LightAttackPressed"",
                    ""type"": ""Button"",
                    ""id"": ""1b941d8e-280d-4613-9bee-046f95104ebc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HeavyAttackPressed"",
                    ""type"": ""Button"",
                    ""id"": ""3b506320-0e56-4a71-89b6-918f0bddf650"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ParadePressed"",
                    ""type"": ""Button"",
                    ""id"": ""c3505972-6f57-470c-8f77-30306a2a2286"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac5d42fd-fcb1-4d75-ae61-25110d16db82"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""754d0456-ddb5-4a1a-ba5b-979bce18800c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""18dd7f95-d241-411a-a740-ec65c40b8546"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dd597a3b-5012-4c7d-94fa-cda327da92ed"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19089b06-1621-4cef-934c-5cd671414df2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d6aa5e30-805d-4146-971a-fe6b808f3fc4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""783d9bc0-2224-4bcc-a0da-3f6463ad5970"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""639f323a-600a-4087-a6ee-8070f59f54d6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5d387d2-84a2-43ab-830a-e80e2458ac7b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""419cceff-929e-4132-afe8-1ee340c35bc8"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc732e64-7f4c-443d-a956-cdbb248cb22d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bc4a02e-5017-420c-8e73-b6c2f689358a"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b910dc05-cb78-45b8-be8f-870afb7cb854"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12e65f03-e20e-4926-8aba-a51fe501e624"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ParadePressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""079af214-0fb2-4938-9ce2-7c1badc54567"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ParadePressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Select = m_Gameplay.FindAction("Select", throwIfNotFound: true);
        m_Gameplay_LightAttackPressed = m_Gameplay.FindAction("LightAttackPressed", throwIfNotFound: true);
        m_Gameplay_HeavyAttackPressed = m_Gameplay.FindAction("HeavyAttackPressed", throwIfNotFound: true);
        m_Gameplay_ParadePressed = m_Gameplay.FindAction("ParadePressed", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Select;
    private readonly InputAction m_Gameplay_LightAttackPressed;
    private readonly InputAction m_Gameplay_HeavyAttackPressed;
    private readonly InputAction m_Gameplay_ParadePressed;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Select => m_Wrapper.m_Gameplay_Select;
        public InputAction @LightAttackPressed => m_Wrapper.m_Gameplay_LightAttackPressed;
        public InputAction @HeavyAttackPressed => m_Wrapper.m_Gameplay_HeavyAttackPressed;
        public InputAction @ParadePressed => m_Wrapper.m_Gameplay_ParadePressed;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Select.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @LightAttackPressed.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLightAttackPressed;
                @LightAttackPressed.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLightAttackPressed;
                @LightAttackPressed.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLightAttackPressed;
                @HeavyAttackPressed.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHeavyAttackPressed;
                @HeavyAttackPressed.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHeavyAttackPressed;
                @HeavyAttackPressed.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHeavyAttackPressed;
                @ParadePressed.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnParadePressed;
                @ParadePressed.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnParadePressed;
                @ParadePressed.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnParadePressed;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @LightAttackPressed.started += instance.OnLightAttackPressed;
                @LightAttackPressed.performed += instance.OnLightAttackPressed;
                @LightAttackPressed.canceled += instance.OnLightAttackPressed;
                @HeavyAttackPressed.started += instance.OnHeavyAttackPressed;
                @HeavyAttackPressed.performed += instance.OnHeavyAttackPressed;
                @HeavyAttackPressed.canceled += instance.OnHeavyAttackPressed;
                @ParadePressed.started += instance.OnParadePressed;
                @ParadePressed.performed += instance.OnParadePressed;
                @ParadePressed.canceled += instance.OnParadePressed;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnLightAttackPressed(InputAction.CallbackContext context);
        void OnHeavyAttackPressed(InputAction.CallbackContext context);
        void OnParadePressed(InputAction.CallbackContext context);
    }
}
