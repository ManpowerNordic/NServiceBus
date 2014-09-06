namespace NServiceBus.Pipeline
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Logging;

    class BehaviorChain<T> where T : BehaviorContext
    {
        // ReSharper disable once StaticFieldInGenericType
        // The number of T's is small and they will all log to the same point due to the typeof(BehaviorChain<>)
        static ILog Log = LogManager.GetLogger(typeof(BehaviorChain<>));
        Queue<Type> itemDescriptors = new Queue<Type>();

        public BehaviorChain(IEnumerable<Type> behaviorList)
        {
            foreach (var behaviorType in behaviorList)
            {
                itemDescriptors.Enqueue(behaviorType);
            }
        }

        public void Invoke(T context)
        {
            InvokeNext(context);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]//The test BehaviorChainTests.When_exception_is_thrown_in_a_release_build_stack_trace_is_trimmed explicitly requires this method to be part of the call stack. If that is not actually a requirement this attribute can be removed.
        void InvokeNext(T context)
        {
            if (itemDescriptors.Count == 0 || context.ChainAborted)
            {
                return;
            }

            var behaviorType = itemDescriptors.Dequeue();
            Log.Debug(behaviorType.Name);

            var instance = (IBehavior<T>)context.Builder.Build(behaviorType);
            instance.Invoke(context, () => InvokeNext(context));
        }
    }
}