using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.Messages;

public class ClearSignatureMessage : ValueChangedMessage<bool>
{
    public ClearSignatureMessage(bool value) : base(value)
    {
    }
}

