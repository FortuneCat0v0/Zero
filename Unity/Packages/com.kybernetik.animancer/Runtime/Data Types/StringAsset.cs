// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2024 Kybernetik //

using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using Object = UnityEngine.Object;

namespace Animancer
{
    /// <summary>
    /// A <see cref="ScriptableObject"/> which holds a <see cref="StringReference"/>
    /// based on its <see cref="Object.name"/>.
    /// </summary>
    /// https://kybernetik.com.au/animancer/api/Animancer/StringAsset
    [AnimancerHelpUrl(typeof(StringAsset))]
    [CreateAssetMenu(
        menuName = Strings.MenuPrefix + "String Asset",
        order = Strings.AssetMenuOrder + 2)]
    public class StringAsset : ScriptableObject,
        IComparable<StringAsset>,
        IConvertable<StringReference>,
        IConvertable<string>,
        IEquatable<StringAsset>,
        IEquatable<StringReference>,
        IEquatable<string>,
        IHasKey
    {
        /************************************************************************************************************************/

        private StringReference _Name;

        /// <summary>A <see cref="StringReference"/> to the <see cref="Object.name"/>.</summary>
        /// <remarks>
        /// This value is gathered when first accessed, but will not be automatically updated after that
        /// because doing so causes some garbage allocation (except in the Unity Editor for convenience).
        /// </remarks>
        public StringReference Name
        {
#if UNITY_EDITOR
            // Don't do this at runtime because it allocates garbage every time.
            // But in the Unity Editor things could get renamed at any time.
            get => _Name = this ? name : "";
#else
            get => _Name ??= name;
#endif
            set => _Name = name = value;
        }

        /// <inheritdoc/>
        public object Key
            => Name;

        /************************************************************************************************************************/
        #region Equality
        /************************************************************************************************************************/

        /// <summary>Compares the <see cref="StringReference.String"/>s.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Compare(StringAsset a, StringAsset b)
            => a == b
            ? 0
            : a
            ? a.CompareTo(b)
            : -1;

        /// <summary>Compares the <see cref="StringReference.String"/>s.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(StringAsset other)
            => other
            ? Name.String.CompareTo(other.Name.String)
            : 1;

        /************************************************************************************************************************/

        /// <summary>Is the <see cref="Name"/> equal to the `other`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(StringAsset other)
            => other is not null
            && Name == other.Name;

        /// <summary>Is the <see cref="Name"/> equal to the `other`?</summary>
        /// <remarks>Uses <see cref="object.ReferenceEquals"/>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(StringReference other)
            => Name == other;

        /// <summary>Is the <see cref="Name"/> equal to the `value`?</summary>
        /// <remarks>Checks regular string equality because the `value` might not be interned.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(string value)
            => Name.String == value;

        /// <summary>Is the <see cref="Name"/> equal to the `other`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object other)
        {
            if (other is StringAsset asset)
                return Equals(asset);

            if (other is StringReference reference)
                return Equals(reference);

            if (other is string value)
                return Equals(value);

            return false;
        }

        /************************************************************************************************************************/

        /// <summary>Are the <see cref="Name"/>s equal?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StringAsset a, StringAsset b)
            => a is null
            ? b is null
            : a.Equals(b);

        /// <summary>Are the <see cref="Name"/>s not equal?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StringAsset a, StringAsset b)
            => a is null
            ? b is not null
            : !a.Equals(b);

        /************************************************************************************************************************/

        /// <summary>Is the <see cref="Name"/> equal to `b`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StringAsset a, StringReference b)
            => a?.Name == b;

        /// <summary>Is the <see cref="Name"/> not equal to `b`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StringAsset a, StringReference b)
            => a?.Name != b;

        /// <summary>Is the <see cref="Name"/> equal to `a`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StringReference a, StringAsset b)
            => a == b?.Name;

        /// <summary>Is the <see cref="Name"/> not equal to `a`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StringReference a, StringAsset b)
            => a != b?.Name;

        /************************************************************************************************************************/

        /// <summary>Is the <see cref="Name"/> equal to `b`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StringAsset a, string b)
            => a?.Name.String == b;

        /// <summary>Is the <see cref="Name"/> not equal to `b`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StringAsset a, string b)
            => a?.Name.String != b;

        /// <summary>Is the <see cref="Name"/> equal to `a`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(string a, StringAsset b)
            => b?.Name.String == a;

        /// <summary>Is the <see cref="Name"/> not equal to `a`?</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(string a, StringAsset b)
            => b?.Name.String != a;

        /************************************************************************************************************************/

        /// <summary>Returns the hash code of the <see cref="Name"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => Name.GetHashCode();

        /************************************************************************************************************************/
        #endregion
        /************************************************************************************************************************/
        #region Conversion
        /************************************************************************************************************************/

        /// <summary>Returns the <see cref="Name"/>.</summary>
        public override string ToString()
            => Name;

        /// <inheritdoc/>
        StringReference IConvertable<StringReference>.Convert()
            => Name;

        /// <inheritdoc/>
        string IConvertable<string>.Convert()
            => Name;

        /************************************************************************************************************************/

        /// <summary>Returns the <see cref="Name"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(StringAsset key)
            => key?.Name;

        /// <summary>Returns the <see cref="Name"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StringReference(StringAsset key)
            => key?.Name;

        /************************************************************************************************************************/

        /// <summary>Creates a new array containing the <see cref="Name"/>s.</summary>
        public static StringReference[] ToStringReferences(params StringAsset[] keys)
        {
            if (keys == null)
                return null;

            if (keys.Length == 0)
                return Array.Empty<StringReference>();

            var strings = new StringReference[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                strings[i] = keys[i];
            return strings;
        }

        /// <summary>Creates a new array containing the <see cref="Name"/>s.</summary>
        public static string[] ToStrings(params StringAsset[] keys)
        {
            if (keys == null)
                return null;

            if (keys.Length == 0)
                return Array.Empty<string>();

            var strings = new string[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                strings[i] = keys[i];
            return strings;
        }

        /************************************************************************************************************************/
        #endregion
        /************************************************************************************************************************/
#if UNITY_EDITOR
        /************************************************************************************************************************/

        [Tooltip("An unused Editor-Only field where you can explain what this asset is used for")]
        [SerializeField, TextArea(2, 25)]
        private string _EditorComment;

        /// <summary>[Editor-Only] [<see cref="SerializeField"/>]
        /// An unused Editor-Only field where you can explain what this asset is used for.
        /// </summary>
        public ref string EditorComment
            => ref _EditorComment;

        /************************************************************************************************************************/
#endif
    }
}
