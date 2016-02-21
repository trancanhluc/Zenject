using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;

#if !ZEN_NOT_UNITY3D
using UnityEngine;
#endif

namespace Zenject
{
    public interface IResolver
    {
        void InjectExplicit(
            object injectable, IEnumerable<TypeValuePair> extraArgs,
            bool shouldUseAll, ZenjectTypeInfo typeInfo, InjectContext context,
            string concreteIdentifier);

#if !ZEN_NOT_UNITY3D
        void InjectGameObject(
            GameObject gameObject);

        void InjectGameObject(
            GameObject gameObject, bool recursive);

        // Inject dependencies into child game objects
        void InjectGameObject(
            GameObject gameObject, bool recursive, bool includeInactive);

        void InjectGameObject(
            GameObject gameObject, bool recursive, bool includeInactive,
            IEnumerable<object> extraArgs);

        void InjectGameObject(
            GameObject gameObject, bool recursive, bool includeInactive,
            IEnumerable<object> extraArgs, InjectContext context);
#endif

        void Inject(object injectable);
        void Inject(object injectable, IEnumerable<object> additional);
        void Inject(object injectable, IEnumerable<object> additional, bool shouldUseAll);

        void Inject(
            object injectable, IEnumerable<object> additional, bool shouldUseAll,
            InjectContext context);

        void Inject(
            object injectable, IEnumerable<object> additional, bool shouldUseAll,
            InjectContext context, ZenjectTypeInfo typeInfo);

        void InjectExplicit(object injectable, List<TypeValuePair> additional);
        void InjectExplicit(object injectable, List<TypeValuePair> additional, InjectContext context);

        List<Type> ResolveTypeAll(InjectContext context);
        List<Type> ResolveTypeAll(Type type);

        object Resolve(InjectContext context);

        TContract Resolve<TContract>();
        TContract Resolve<TContract>(string identifier);

        TContract TryResolve<TContract>()
            where TContract : class;
        TContract TryResolve<TContract>(string identifier)
            where TContract : class;

        object TryResolve(Type contractType);
        object TryResolve(Type contractType, string identifier);

        object Resolve(Type contractType);
        object Resolve(Type contractType, string identifier);

        TContract Resolve<TContract>(InjectContext context);

        IList ResolveAll(InjectContext context);

        List<TContract> ResolveAll<TContract>();
        List<TContract> ResolveAll<TContract>(bool optional);
        List<TContract> ResolveAll<TContract>(string identifier);
        List<TContract> ResolveAll<TContract>(string identifier, bool optional);
        List<TContract> ResolveAll<TContract>(InjectContext context);

        IList ResolveAll(Type contractType);
        IList ResolveAll(Type contractType, string identifier);
        IList ResolveAll(Type contractType, bool optional);
        IList ResolveAll(Type contractType, string identifier, bool optional);

        IEnumerable<ZenjectResolveException> ValidateResolve(InjectContext context);

        IEnumerable<ZenjectResolveException> ValidateResolve<TContract>();
        IEnumerable<ZenjectResolveException> ValidateResolve<TContract>(string identifier);

        IEnumerable<ZenjectResolveException> ValidateResolve(Type contractType);
        IEnumerable<ZenjectResolveException> ValidateResolve(Type contractType, string identifier);

        IEnumerable<ZenjectResolveException> ValidateValidatables(params Type[] ignoreTypes);

        // This will validate everything - not just those types that are are in the initial
        // object graph which is what ValidateValidatables does
        // However, this will fail in some valid cases, when using complex conditions that 
        // involve looking at the inject stack
        // You probably want to use ValidateValidatables
        IEnumerable<ZenjectResolveException> ValidateAll(params Type[] ignoreTypes);

        IEnumerable<ZenjectResolveException> ValidateObjectGraph<TConcrete>(
            params Type[] extras);

        IEnumerable<ZenjectResolveException> ValidateObjectGraph(
            Type concreteType, InjectContext currentContext, string concreteIdentifier,
            params Type[] extras);

        IEnumerable<ZenjectResolveException> ValidateObjectGraph(
            Type contractType, InjectContext context, params Type[] extras);

        IEnumerable<ZenjectResolveException> ValidateObjectGraph(
            Type contractType, params Type[] extras);

        IEnumerable<ZenjectResolveException> ValidateObjectGraph<TConcrete>(
            InjectContext context, params Type[] extras);

        IInstantiator Instantiator
        {
            get;
        }

        IBinder Binder
        {
            get;
        }
    }
}