﻿// This file is part of Capy64 - https://github.com/Capy64/Capy64
// Copyright 2023 Alessandro "AlexDevs" Proto
//
//    Licensed under the Apache License, Version 2.0 (the "License").
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0

using Microsoft.Xna.Framework;
using System;

namespace Capy64.Eventing.Events;

public class MouseWheelEvent : EventArgs
{
    public Point Position { get; set; }
    public int VerticalValue { get; set; }
    public int HorizontalValue { get; set; }
}
