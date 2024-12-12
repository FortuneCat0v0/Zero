// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2024 Kybernetik //

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
    /// <summary>A <see cref="ScriptableObject"/> based <see cref="ITransition"/>.</summary>
    /// <remarks>
    /// <strong>Documentation:</strong>
    /// <see href="https://kybernetik.com.au/animancer/docs/manual/transitions/assets">
    /// Transition Assets</see>
    /// <para></para>
    /// When adding a <see cref="CreateAssetMenuAttribute"/> to any derived classes, you can use
    /// <see cref="Strings.MenuPrefix"/> and <see cref="Strings.AssetMenuOrder"/>.
    /// </remarks>
    /// https://kybernetik.com.au/animancer/api/Animancer/TransitionAssetBase
    [AnimancerHelpUrl(typeof(TransitionAssetBase))]
    public abstract partial class TransitionAssetBase : ScriptableObject,
        ITransition,
        ITransitionDetailed,
        IWrapper,
        IAnimationClipSource
    {
        /************************************************************************************************************************/

        /// <summary>The name of the serialized backing field of <see cref="GetTransition"/>.</summary>
        public const string TransitionField = "_Transition";

        /************************************************************************************************************************/

        /// <summary>Returns the <see cref="ITransitionDetailed"/> wrapped by this <see cref="ScriptableObject"/>.</summary>
        public abstract ITransitionDetailed GetTransition();

        /// <inheritdoc/>
        object IWrapper.WrappedObject
            => this != null
            ? GetTransition()
            : null;

        /************************************************************************************************************************/

        /// <inheritdoc/>
        public virtual float FadeDuration => GetTransition().FadeDuration;

        /// <inheritdoc/>
        public virtual object Key => GetTransition().Key;

        /// <inheritdoc/>
        public virtual FadeMode FadeMode => GetTransition().FadeMode;

        /// <inheritdoc/>
        public virtual AnimancerState CreateState() => GetTransition().CreateState();

        /// <inheritdoc/>
        public virtual void Apply(AnimancerState state)
        {
            GetTransition().Apply(state);
            state.SetDebugName(this);
        }

        /************************************************************************************************************************/

        /// <summary>Can this transition create a valid <see cref="AnimancerState"/>?</summary>
        /// <remarks>
        /// Use <see cref="AnimancerUtilities.IsValid(ITransition)"/>
        /// to also null check this reference, i.e: <c>transition.IsValid()</c>.
        /// </remarks>
        public virtual bool IsValid
            => this != null
            && GetTransition().IsValid();

        /// <inheritdoc/>
        public bool IsLooping => GetTransition().IsLooping;

        /// <inheritdoc/>
        public float NormalizedStartTime
        {
            get => GetTransition().NormalizedStartTime;
            set => GetTransition().NormalizedStartTime = value;
        }

        /// <inheritdoc/>
        public float MaximumDuration => GetTransition().MaximumDuration;

        /// <inheritdoc/>
        public float Speed
        {
            get => GetTransition().Speed;
            set => GetTransition().Speed = value;
        }

        /************************************************************************************************************************/

        /// <summary>[<see cref="IAnimationClipSource"/>]
        /// Calls <see cref="AnimancerUtilities.GatherFromSource(ICollection{AnimationClip}, object)"/>.
        /// </summary>
        public virtual void GetAnimationClips(List<AnimationClip> clips)
            => clips.GatherFromSource(GetTransition());

        /************************************************************************************************************************/

#if UNITY_EDITOR
        /// <summary>[Editor-Only] Creates an instance of the main non-abstract inheritor of this class.</summary>
        /// <remarks><c>TransitionAsset</c> sets this to use itself by default.</remarks>
        public static new Func<ITransitionDetailed, TransitionAssetBase> CreateInstance { get; set; }
#endif

        /************************************************************************************************************************/
    }
}

