using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.Messages;

public class SaveSignatureMessage : ValueChangedMessage<int>
{
    public SaveSignatureMessage(int value) : base(value)
    {
    }
}

