﻿using Capy64.API;
using KeraLua;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Capy64.Runtime;

public class ObjectManager : IPlugin
{
    private static ConcurrentDictionary<nint, object> _objects = new();

    private static IGame _game;
    public ObjectManager(IGame game)
    {
        _game = game;
        _game.EventEmitter.OnClose += OnClose;
    }

    public static void PushObject<T>(Lua L, T obj)
    {
        if (obj == null)
        {
            L.PushNil();
            return;
        }

        var p = L.NewUserData(1);
        _objects[p] = obj;
    }

    public static T ToObject<T>(Lua L, int index, bool freeGCHandle = true)
    {
        if (L.IsNil(index) || !L.IsUserData(index))
            return default(T);

        var data = L.ToUserData(index);
        if (data == IntPtr.Zero)
            return default(T);

        if (!_objects.ContainsKey(data))
            return default(T);

        var reference = (T)_objects[data];

        if (freeGCHandle)
            _objects.Remove(data, out _);

        return reference;
    }

    public static T CheckObject<T>(Lua L, int argument, string typeName, bool freeGCHandle = true)
    {
        if (L.IsNil(argument) || !L.IsUserData(argument))
            return default(T);

        IntPtr data = L.CheckUserData(argument, typeName);
        if (data == IntPtr.Zero)
            return default(T);

        if (!_objects.ContainsKey(data))
            return default(T);

        var reference = (T)_objects[data];

        if (freeGCHandle)
            _objects.Remove(data, out _);

        return reference;
    }

    private void OnClose(object sender, EventArgs e)
    {
        _objects.Clear();
    }
}