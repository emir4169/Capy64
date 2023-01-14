﻿using Capy64.Extensions.Bindings;
using Microsoft.Xna.Framework;
using System;

namespace Capy64.Extensions;

public static class GameWindowExtensions
{
    /// <summary>
    /// <see cref="https://github.com/flibitijibibo/SDL2-CS/blob/master/src/SDL2.cs#L1530"/>
    /// </summary>
    [Flags]
    public enum WindowFlags : uint
    {
        SDL_WINDOW_FULLSCREEN = 0x00000001,
        SDL_WINDOW_OPENGL = 0x00000002,
        SDL_WINDOW_SHOWN = 0x00000004,
        SDL_WINDOW_HIDDEN = 0x00000008,
        SDL_WINDOW_BORDERLESS = 0x00000010,
        SDL_WINDOW_RESIZABLE = 0x00000020,
        SDL_WINDOW_MINIMIZED = 0x00000040,
        SDL_WINDOW_MAXIMIZED = 0x00000080,
        SDL_WINDOW_MOUSE_GRABBED = 0x00000100,
        SDL_WINDOW_INPUT_FOCUS = 0x00000200,
        SDL_WINDOW_MOUSE_FOCUS = 0x00000400,
        SDL_WINDOW_FULLSCREEN_DESKTOP =
            SDL_WINDOW_FULLSCREEN | 0x00001000,
        SDL_WINDOW_FOREIGN = 0x00000800,
        SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000,
        SDL_WINDOW_MOUSE_CAPTURE = 0x00004000,
        SDL_WINDOW_ALWAYS_ON_TOP = 0x00008000,
        SDL_WINDOW_SKIP_TASKBAR = 0x00010000,
        SDL_WINDOW_UTILITY = 0x00020000,
        SDL_WINDOW_TOOLTIP = 0x00040000,
        SDL_WINDOW_POPUP_MENU = 0x00080000,
        SDL_WINDOW_KEYBOARD_GRABBED = 0x00100000,
        SDL_WINDOW_VULKAN = 0x10000000,
        SDL_WINDOW_METAL = 0x2000000,

        SDL_WINDOW_INPUT_GRABBED =
            SDL_WINDOW_MOUSE_GRABBED,
    }

    public static WindowFlags GetWindowFlags(this GameWindow window)
    {
        return (WindowFlags)SDL2.SDL_GetWindowFlags(window.Handle);
    }

    public static void MaximizeWindow(this GameWindow window)
    {
        SDL2.SDL_MaximizeWindow(window.Handle);
    }
    public static bool IsMaximized(this GameWindow window)
    {
        return window.GetWindowFlags().HasFlag(WindowFlags.SDL_WINDOW_MAXIMIZED);
    }
}
