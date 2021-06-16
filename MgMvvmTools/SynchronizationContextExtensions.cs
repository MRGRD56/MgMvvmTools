using System;
using System.Threading;

namespace MgMvvmTools
{
    public static class SynchronizationContextExtensions
    {
        public static void Send(this SynchronizationContext synchronizationContext, Action d)
        {
            synchronizationContext.Send(_ => d(), null);
        }
        
        public static void Post(this SynchronizationContext synchronizationContext, Action d)
        {
            synchronizationContext.Post(_ => d(), null);
        }
    }
}