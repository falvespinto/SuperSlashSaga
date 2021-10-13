// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Menu Script/InputForMenu.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputForMenu : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputForMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputForMenu"",
    ""maps"": [
        {
            ""name"": ""menu"",
            ""id"": ""9b83f753-7e59-40c1-9613-ca5c0eb3c0c6"",
            ""actions"": [
                {
                    ""name"": ""ButtonUp"",
                    ""type"": ""Button"",
                    ""id"": ""59c9d5fe-6b2b-417d-8487-73ac66c562b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonDown"",
                    ""type"": ""Button"",
                    ""id"": ""b832d2e7-2d33-413f-923a-4369ddd309eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Play"",
                    ""type"": ""Button"",
                    ""id"": ""8429a372-4fcc-4432-9a8a-c91a9fdc3931"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonRight"",
                    ""type"": ""Button"",
                    ""id"": ""06cdd631-125f-4dc9-bf7e-d36bb9990c1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonLeft"",
                    ""type"": ""Button"",
                    ""id"": ""7f74231c-68f2-4185-8eb6-963d3ba49ca4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""20917f78-d21e-4836-8ba3-eb6b0fc7d958"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""84454796-9d58-457c-a726-bdf3e063596c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyRight"",
                    ""type"": ""Button"",
                    ""id"": ""75746d3b-dff6-4598-9f53-046e491c189d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyLeft"",
                    ""type"": ""Button"",
                    ""id"": ""1bcb5843-4092-4bf7-94af-9559b7f19b84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyUp"",
                    ""type"": ""Button"",
                    ""id"": ""f6ec2831-99b8-4806-82a3-319476436376"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyDown"",
                    ""type"": ""Button"",
                    ""id"": ""09261068-6e8a-4847-ae95-ccfa54b50558"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""020760e6-72ee-455e-8d5d-ac13cf7c5e7f"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""911d7a88-4192-452e-a5d0-1e3cdaadde3f"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe4aebf3-3a0d-4013-8de4-5354e7c5acbc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99269095-b758-4db2-8dcf-38ebb3fe01da"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""087d9f6d-3077-48cb-874c-8cff77ad4bd9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e18a6593-818c-4d77-a9d4-89fa8f4c9ae8"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8098fbe9-6f79-4d9e-8c69-ffb3ffc90766"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""754c6157-0869-473f-bae0-667b344f0454"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a0c51c7-451f-4aa4-bcb8-60482dfd9534"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e53ff7a0-1905-47b7-89d5-0c5fa9967c43"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9733ac2f-996f-437e-8f82-e8968e8bdf33"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd50efe8-eb1a-49ef-bbb7-7800c3b02e1b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""542c7f6e-e730-4462-a143-06a015874214"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // menu
        m_menu = asset.FindActionMap("menu", throwIfNotFound: true);
        m_menu_ButtonUp = m_menu.FindAction("ButtonUp", throwIfNotFound: true);
        m_menu_ButtonDown = m_menu.FindAction("ButtonDown", throwIfNotFound: true);
        m_menu_Play = m_menu.FindAction("Play", throwIfNotFound: true);
        m_menu_ButtonRight = m_menu.FindAction("ButtonRight", throwIfNotFound: true);
        m_menu_ButtonLeft = m_menu.FindAction("ButtonLeft", throwIfNotFound: true);
        m_menu_Pause = m_menu.FindAction("Pause", throwIfNotFound: true);
        m_menu_A = m_menu.FindAction("A", throwIfNotFound: true);
        m_menu_JoyRight = m_menu.FindAction("JoyRight", throwIfNotFound: true);
        m_menu_JoyLeft = m_menu.FindAction("JoyLeft", throwIfNotFound: true);
        m_menu_JoyUp = m_menu.FindAction("JoyUp", throwIfNotFound: true);
        m_menu_JoyDown = m_menu.FindAction("JoyDown", throwIfNotFound: true);
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

    // menu
    private readonly InputActionMap m_menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_menu_ButtonUp;
    private readonly InputAction m_menu_ButtonDown;
    private readonly InputAction m_menu_Play;
    private readonly InputAction m_menu_ButtonRight;
    private readonly InputAction m_menu_ButtonLeft;
    private readonly InputAction m_menu_Pause;
    private readonly InputAction m_menu_A;
    private readonly InputAction m_menu_JoyRight;
    private readonly InputAction m_menu_JoyLeft;
    private readonly InputAction m_menu_JoyUp;
    private readonly InputAction m_menu_JoyDown;
    public struct MenuActions
    {
        private @InputForMenu m_Wrapper;
        public MenuActions(@InputForMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonUp => m_Wrapper.m_menu_ButtonUp;
        public InputAction @ButtonDown => m_Wrapper.m_menu_ButtonDown;
        public InputAction @Play => m_Wrapper.m_menu_Play;
        public InputAction @ButtonRight => m_Wrapper.m_menu_ButtonRight;
        public InputAction @ButtonLeft => m_Wrapper.m_menu_ButtonLeft;
        public InputAction @Pause => m_Wrapper.m_menu_Pause;
        public InputAction @A => m_Wrapper.m_menu_A;
        public InputAction @JoyRight => m_Wrapper.m_menu_JoyRight;
        public InputAction @JoyLeft => m_Wrapper.m_menu_JoyLeft;
        public InputAction @JoyUp => m_Wrapper.m_menu_JoyUp;
        public InputAction @JoyDown => m_Wrapper.m_menu_JoyDown;
        public InputActionMap Get() { return m_Wrapper.m_menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @ButtonUp.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonUp;
                @ButtonUp.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonUp;
                @ButtonUp.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonUp;
                @ButtonDown.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonDown;
                @ButtonDown.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonDown;
                @ButtonDown.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonDown;
                @Play.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPlay;
                @Play.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPlay;
                @Play.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPlay;
                @ButtonRight.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonRight;
                @ButtonRight.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonRight;
                @ButtonRight.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonRight;
                @ButtonLeft.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonLeft;
                @ButtonLeft.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonLeft;
                @ButtonLeft.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnButtonLeft;
                @Pause.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @A.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnA;
                @JoyRight.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyRight;
                @JoyRight.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyRight;
                @JoyRight.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyRight;
                @JoyLeft.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyLeft;
                @JoyLeft.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyLeft;
                @JoyLeft.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyLeft;
                @JoyUp.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyUp;
                @JoyUp.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyUp;
                @JoyUp.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyUp;
                @JoyDown.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyDown;
                @JoyDown.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyDown;
                @JoyDown.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoyDown;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ButtonUp.started += instance.OnButtonUp;
                @ButtonUp.performed += instance.OnButtonUp;
                @ButtonUp.canceled += instance.OnButtonUp;
                @ButtonDown.started += instance.OnButtonDown;
                @ButtonDown.performed += instance.OnButtonDown;
                @ButtonDown.canceled += instance.OnButtonDown;
                @Play.started += instance.OnPlay;
                @Play.performed += instance.OnPlay;
                @Play.canceled += instance.OnPlay;
                @ButtonRight.started += instance.OnButtonRight;
                @ButtonRight.performed += instance.OnButtonRight;
                @ButtonRight.canceled += instance.OnButtonRight;
                @ButtonLeft.started += instance.OnButtonLeft;
                @ButtonLeft.performed += instance.OnButtonLeft;
                @ButtonLeft.canceled += instance.OnButtonLeft;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @JoyRight.started += instance.OnJoyRight;
                @JoyRight.performed += instance.OnJoyRight;
                @JoyRight.canceled += instance.OnJoyRight;
                @JoyLeft.started += instance.OnJoyLeft;
                @JoyLeft.performed += instance.OnJoyLeft;
                @JoyLeft.canceled += instance.OnJoyLeft;
                @JoyUp.started += instance.OnJoyUp;
                @JoyUp.performed += instance.OnJoyUp;
                @JoyUp.canceled += instance.OnJoyUp;
                @JoyDown.started += instance.OnJoyDown;
                @JoyDown.performed += instance.OnJoyDown;
                @JoyDown.canceled += instance.OnJoyDown;
            }
        }
    }
    public MenuActions @menu => new MenuActions(this);
    public interface IMenuActions
    {
        void OnButtonUp(InputAction.CallbackContext context);
        void OnButtonDown(InputAction.CallbackContext context);
        void OnPlay(InputAction.CallbackContext context);
        void OnButtonRight(InputAction.CallbackContext context);
        void OnButtonLeft(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnJoyRight(InputAction.CallbackContext context);
        void OnJoyLeft(InputAction.CallbackContext context);
        void OnJoyUp(InputAction.CallbackContext context);
        void OnJoyDown(InputAction.CallbackContext context);
    }
}
