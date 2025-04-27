namespace AcuSharp.Extension
{
    /// <summary>
    /// Provides a collection of general-purpose extension methods commonly used across Acumatica ERP customizations.
    /// <para>
    /// This static class is intended to centralize reusable logic for simplifying business workflows, data processing,
    /// and common programming patterns.
    /// </para>
    /// <para>
    /// Additional helper methods should be added here as the library grows.
    /// </para>
    /// </summary>
    public static class ACSPExtensions
    {
        /// <summary>
        /// Checks if the nullable boolean is true.
        /// </summary>
        /// <param name="bool"></param>
        /// <returns> Returns <see langword="true"/> if the value is not null and is <see langword="true"/>; otherwise <see langword="false"/> </returns>
        public static bool IsTrue(this bool? @bool) => @bool == true;

        /// <summary>
        /// Checks if the nullable boolean is false.
        /// </summary>
        /// <param name="bool"></param>
        /// <returns> Returns <see langword="true"/> if the value is not null and is <see langword="false"/>; otherwise <see langword="false"/></returns>
        public static bool IsFalse(this bool? @bool) => @bool != true;

        /// <summary>
        /// Attempts to cast the given object to the specified type.
        /// <para>This can be used to safely cast an object to a DAC instance or any reference type.</para>
        /// </summary>
        /// <typeparam name="TClass">The target type to cast to.</typeparam>
        /// <param name="object">The source object.</param>
        /// <param name="instance">When this method returns, contains the casted instance if the cast succeeded; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the cast was successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryCastTo<TClass>(this object @object, out TClass instance) where TClass : class
        {
            instance = @object as TClass;
            return instance is not null;
        }

        /// <inheritdoc cref="TryCastTo{TClass}(object, out TClass)"/>
        public static bool TryCastTo<TClass>(this PXResult @object, out TClass instance) where TClass : class, IBqlTable
        {
            instance = null;

            if (@object == null)
                return false;

            try
            {
                instance = @object.GetItem<TClass>();
                return instance is not null;
            }
            catch
            {
                return false;
            }
        }
    }
}
