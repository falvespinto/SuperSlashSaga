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
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1de33edc-8d30-47e0-a16c-1f286c90034f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BottomLightAttackPressed"",
                    ""type"": ""Button"",
                    ""id"": ""0d6b1aee-9ef1-4100-96df-aeeb63acec6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BottomHeavyAttackPressed"",
                    ""type"": ""Button"",
                    ""id"": ""425d73c4-c162-4470-b01f-399a8dd9163d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ultimate"",
                    ""type"": ""Button"",
                    ""id"": ""04fd6ece-39d7-4342-8211-cf6accd8df4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""test"",
                    ""type"": ""Button"",
                    ""id"": ""b781e722-57e0-410a-a976-2c1c51880a52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""test2"",
                    ""type"": ""Button"",
                    ""id"": ""025eaf4f-8414-43b5-a50e-cf1169bdb56b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Projectile"",
                    ""type"": ""Button"",
                    ""id"": ""461af858-ad79-4e7c-bb64-e5a4c1e4248c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Permutation"",
                    ""type"": ""Button"",
                    ""id"": ""06d5c27b-4ffb-439e-8cdd-1a85583e8f44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ManaUp"",
                    ""type"": ""Button"",
                    ""id"": ""7f25855d-d268-4b71-ba42-af78ac4a64f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AskForHelp"",
                    ""type"": ""Button"",
                    ""id"": ""25f71125-103f-4e18-82f9-3c2af7bc25c6"",
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
                    ""processors"": ""StickDeadzone"",
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
                    ""interactions"": """",
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
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2013edd7-eb4c-485a-9217-4cd484c87f60"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
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
                },
                {
                    ""name"": """",
                    ""id"": ""f9533f10-a52d-420d-a00c-ee6739f2daca"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39588081-60b8-4a71-acae-6e368a5bbfe7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3540a509-d399-4ab0-965f-4d557e5e4b2c"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BottomLightAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8ebe812-2617-462e-8f54-45f7f6c6840a"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BottomHeavyAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af6130d0-c2d4-409d-8442-5f1ecbfd3862"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BottomHeavyAttackPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ab86e67-4599-4eea-8294-17ca11f04251"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ultimate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c761e0b-db17-4108-9552-45ef52c7c2ea"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ultimate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faa5492f-821f-4822-b31b-37a7a9faad52"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd78b32d-a6c9-4d8a-969a-7481b2882a90"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e622afb8-c761-4c5f-a975-2c0f5d318a57"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""test2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c06baf-c773-4449-b2c6-bd7e704f5cd6"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""test2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64d77611-9cf5-4194-863a-25d20bec897a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Permutation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05ffd42-abfe-418d-996f-8f29e908a735"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ManaUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70cda5c7-0cc8-4a79-aae5-470e22f5a03f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ManaUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""381f7928-ac89-4748-b406-da7d690a77b3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Projectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30095179-8bb1-4aa2-b344-289be7cc7aee"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AskForHelp"",
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
        m_Gameplay_LookAround = m_Gameplay.FindAction("LookAround", throwIfNotFound: true);
        m_Gameplay_BottomLightAttackPressed = m_Gameplay.FindAction("BottomLightAttackPressed", throwIfNotFound: true);
        m_Gameplay_BottomHeavyAttackPressed = m_Gameplay.FindAction("BottomHeavyAttackPressed", throwIfNotFound: true);
        m_Gameplay_Ultimate = m_Gameplay.FindAction("Ultimate", throwIfNotFound: true);
        m_Gameplay_test = m_Gameplay.FindAction("test", throwIfNotFound: true);
        m_Gameplay_test2 = m_Gameplay.FindAction("test2", throwIfNotFound: true);
        m_Gameplay_Projectile = m_Gameplay.FindAction("Projectile", throwIfNotFound: true);
        m_Gameplay_Permutation = m_Gameplay.FindAction("Permutation", throwIfNotFound: true);
        m_Gameplay_ManaUp = m_Gameplay.FindAction("ManaUp", throwIfNotFound: true);
        m_Gameplay_AskForHelp = m_Gameplay.FindAction("AskForHelp", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_LookAround;
    private readonly InputAction m_Gameplay_BottomLightAttackPressed;
    private readonly InputAction m_Gameplay_BottomHeavyAttackPressed;
    private readonly InputAction m_Gameplay_Ultimate;
    private readonly InputAction m_Gameplay_test;
    private readonly InputAction m_Gameplay_test2;
    private readonly InputAction m_Gameplay_Projectile;
    private readonly InputAction m_Gameplay_Permutation;
    private readonly InputAction m_Gameplay_ManaUp;
    private readonly InputAction m_Gameplay_AskForHelp;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Select => m_Wrapper.m_Gameplay_Select;
        public InputAction @LightAttackPressed => m_Wrapper.m_Gameplay_LightAttackPressed;
        public InputAction @HeavyAttackPressed => m_Wrapper.m_Gameplay_HeavyAttackPressed;
        public InputAction @ParadePressed => m_Wrapper.m_Gameplay_ParadePressed;
        public InputAction @LookAround => m_Wrapper.m_Gameplay_LookAround;
        public InputAction @BottomLightAttackPressed => m_Wrapper.m_Gameplay_BottomLightAttackPressed;
        public InputAction @BottomHeavyAttackPressed => m_Wrapper.m_Gameplay_BottomHeavyAttackPressed;
        public InputAction @Ultimate => m_Wrapper.m_Gameplay_Ultimate;
        public InputAction @test => m_Wrapper.m_Gameplay_test;
        public InputAction @test2 => m_Wrapper.m_Gameplay_test2;
        public InputAction @Projectile => m_Wrapper.m_Gameplay_Projectile;
        public InputAction @Permutation => m_Wrapper.m_Gameplay_Permutation;
        public InputAction @ManaUp => m_Wrapper.m_Gameplay_ManaUp;
        public InputAction @AskForHelp => m_Wrapper.m_Gameplay_AskForHelp;
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
                @LookAround.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLookAround;
                @BottomLightAttackPressed.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBottomLightAttackPressed;
                @BottomLightAttackPressed.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBottomLightAttackPressed;
                @BottomLightAttackPressed.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBottomLightAttackPressed;
                @BottomHeavyAttackPressed.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBottomHeavyAttackPressed;
                @BottomHeavyAttackPressed.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBottomHeavyAttackPressed;
                @BottomHeavyAttackPressed.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBottomHeavyAttackPressed;
                @Ultimate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @test.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTest;
                @test.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTest;
                @test.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTest;
                @test2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTest2;
                @test2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTest2;
                @test2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTest2;
                @Projectile.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectile;
                @Projectile.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectile;
                @Projectile.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectile;
                @Permutation.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPermutation;
                @Permutation.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPermutation;
                @Permutation.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPermutation;
                @ManaUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnManaUp;
                @ManaUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnManaUp;
                @ManaUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnManaUp;
                @AskForHelp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAskForHelp;
                @AskForHelp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAskForHelp;
                @AskForHelp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAskForHelp;
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
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
                @BottomLightAttackPressed.started += instance.OnBottomLightAttackPressed;
                @BottomLightAttackPressed.performed += instance.OnBottomLightAttackPressed;
                @BottomLightAttackPressed.canceled += instance.OnBottomLightAttackPressed;
                @BottomHeavyAttackPressed.started += instance.OnBottomHeavyAttackPressed;
                @BottomHeavyAttackPressed.performed += instance.OnBottomHeavyAttackPressed;
                @BottomHeavyAttackPressed.canceled += instance.OnBottomHeavyAttackPressed;
                @Ultimate.started += instance.OnUltimate;
                @Ultimate.performed += instance.OnUltimate;
                @Ultimate.canceled += instance.OnUltimate;
                @test.started += instance.OnTest;
                @test.performed += instance.OnTest;
                @test.canceled += instance.OnTest;
                @test2.started += instance.OnTest2;
                @test2.performed += instance.OnTest2;
                @test2.canceled += instance.OnTest2;
                @Projectile.started += instance.OnProjectile;
                @Projectile.performed += instance.OnProjectile;
                @Projectile.canceled += instance.OnProjectile;
                @Permutation.started += instance.OnPermutation;
                @Permutation.performed += instance.OnPermutation;
                @Permutation.canceled += instance.OnPermutation;
                @ManaUp.started += instance.OnManaUp;
                @ManaUp.performed += instance.OnManaUp;
                @ManaUp.canceled += instance.OnManaUp;
                @AskForHelp.started += instance.OnAskForHelp;
                @AskForHelp.performed += instance.OnAskForHelp;
                @AskForHelp.canceled += instance.OnAskForHelp;
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
        void OnLookAround(InputAction.CallbackContext context);
        void OnBottomLightAttackPressed(InputAction.CallbackContext context);
        void OnBottomHeavyAttackPressed(InputAction.CallbackContext context);
        void OnUltimate(InputAction.CallbackContext context);
        void OnTest(InputAction.CallbackContext context);
        void OnTest2(InputAction.CallbackContext context);
        void OnProjectile(InputAction.CallbackContext context);
        void OnPermutation(InputAction.CallbackContext context);
        void OnManaUp(InputAction.CallbackContext context);
        void OnAskForHelp(InputAction.CallbackContext context);
    }
}
