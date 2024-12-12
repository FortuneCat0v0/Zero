// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2024 Kybernetik //

using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Animancer
{
    /// <summary>[Pro-Only]
    /// An <see cref="AnimancerState"/> which blends an array of other states together
    /// based on a two dimensional parameter and thresholds.
    /// </summary>
    /// <remarks>
    /// <strong>Documentation:</strong>
    /// <see href="https://kybernetik.com.au/animancer/docs/manual/blending/mixers">
    /// Mixers</see>
    /// </remarks>
    /// https://kybernetik.com.au/animancer/api/Animancer/Vector2MixerState
    /// 
    public abstract class Vector2MixerState : MixerState<Vector2>,
        ICopyable<Vector2MixerState>
    {
        /************************************************************************************************************************/

        /// <summary><see cref="MixerState{TParameter}.Parameter"/>.x.</summary>
        public float ParameterX
        {
            get => Parameter.x;
            set => Parameter = new(value, Parameter.y);
        }

        /// <summary><see cref="MixerState{TParameter}.Parameter"/>.y.</summary>
        public float ParameterY
        {
            get => Parameter.y;
            set => Parameter = new(Parameter.x, value);
        }

        /************************************************************************************************************************/
        #region Parameter Binding
        /************************************************************************************************************************/

        private NodeParameter<float> _ParameterBindingX;

        /// <summary>
        /// If set, this will be used as a key in the <see cref="ParameterDictionary"/> so any
        /// changes to that parameter will automatically set the <see cref="ParameterX"/>.
        /// </summary>
        public StringReference ParameterNameX
        {
            get => _ParameterBindingX.Key;
            set
            {
                if (_ParameterBindingX.SetKeyCheckNeedsInitialize(value))
                    _ParameterBindingX.Initialize(this, parameter => ParameterX = parameter);
            }
        }

        /************************************************************************************************************************/

        private NodeParameter<float> _ParameterBindingY;

        /// <summary>
        /// If set, this will be used as a key in the <see cref="ParameterDictionary"/> so any
        /// changes to that parameter will automatically set the <see cref="ParameterY"/>.
        /// </summary>
        public StringReference ParameterNameY
        {
            get => _ParameterBindingY.Key;
            set
            {
                if (_ParameterBindingY.SetKeyCheckNeedsInitialize(value))
                    _ParameterBindingY.Initialize(this, parameter => ParameterY = parameter);
            }
        }

        /************************************************************************************************************************/

        /// <inheritdoc/>
        public override void SetGraph(AnimancerGraph graph)
        {
            if (Graph == graph)
                return;

            _ParameterBindingX.UnBindIfInitialized();
            _ParameterBindingY.UnBindIfInitialized();

            base.SetGraph(graph);

            _ParameterBindingX.BindIfInitialized();
            _ParameterBindingY.BindIfInitialized();
        }

        /************************************************************************************************************************/

        /// <inheritdoc/>
        public override void Destroy()
        {
            base.Destroy();

            _ParameterBindingX.UnBindIfInitialized();
            _ParameterBindingY.UnBindIfInitialized();
        }

        /************************************************************************************************************************/

        /// <inheritdoc/>
        public sealed override void CopyFrom(MixerState<Vector2> copyFrom, CloneContext context)
            => this.CopyFromBase(copyFrom, context);

        /// <inheritdoc/>
        public virtual void CopyFrom(Vector2MixerState copyFrom, CloneContext context)
        {
            base.CopyFrom(copyFrom, context);

            ParameterNameX = copyFrom.ParameterNameX;
            ParameterNameY = copyFrom.ParameterNameY;
        }

        /************************************************************************************************************************/
        #endregion
        /************************************************************************************************************************/

        /// <summary>Gets the lowest and highest threshold values on each axis.</summary>
        public void GetThresholdBounds(out Vector2 min, out Vector2 max)
        {
            var i = ChildCount - 1;
            min = max = GetThreshold(i);

            i--;
            for (; i >= 0; i--)
            {
                var threshold = GetThreshold(i);

                if (min.x > threshold.x)
                    min.x = threshold.x;

                if (min.y > threshold.y)
                    min.y = threshold.y;

                if (max.x < threshold.x)
                    max.x = threshold.x;

                if (max.y < threshold.y)
                    max.y = threshold.y;
            }
        }

        /// <inheritdoc/>
        public override Vector2 NormalizedParameter
        {
            get
            {
                GetThresholdBounds(out var min, out var max);
                var value = Parameter;
                return new(
                    AnimancerUtilities.InverseLerpUnclamped(min.x, max.x, value.x),
                    AnimancerUtilities.InverseLerpUnclamped(min.y, max.y, value.y));
            }
            set
            {
                GetThresholdBounds(out var min, out var max);
                Parameter = new(
                    Mathf.LerpUnclamped(min.x, max.x, value.x),
                    Mathf.LerpUnclamped(min.y, max.y, value.y));
            }
        }

        /************************************************************************************************************************/

        /// <inheritdoc/>
        public override string GetParameterError(Vector2 value)
            => value.IsFinite()
            ? null
            : $"value.x and value.y {Strings.MustBeFinite}";

        /************************************************************************************************************************/

        /// <inheritdoc/>
        public override void AppendParameter(StringBuilder text, Vector2 parameter)
        {
            text.Append('(')
                .Append(parameter.x)
                .Append(", ")
                .Append(parameter.y)
                .Append(')');
        }

        /************************************************************************************************************************/
        #region Inspector
        /************************************************************************************************************************/

        /// <inheritdoc/>
        public override void GetParameters(List<StateParameterDetails> parameters)
        {
            parameters.Add(new(
                "Parameter X",
                ParameterNameX,
                AnimatorControllerParameterType.Float,
                ParameterX));
            parameters.Add(new(
                "Parameter Y",
                ParameterNameY,
                AnimatorControllerParameterType.Float,
                ParameterY));
        }

        /// <inheritdoc/>
        public override void SetParameters(List<StateParameterDetails> parameters)
        {
            var parameter = parameters[0];
            ParameterNameX = parameter.name;
            ParameterX = (float)parameter.value;

            parameter = parameters[1];
            ParameterNameY = parameter.name;
            ParameterY = (float)parameter.value;
        }

        /************************************************************************************************************************/
        #endregion
        /************************************************************************************************************************/
    }
}

