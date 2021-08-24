using System;
using Balta.NotificationContext;

namespace Balta.SharedContext
{
    //Classe Base tem tudo que irá se repetir em todas as classes
    //Base herda de Notifiable, logo Base pode usar os métodos de notifiable
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}