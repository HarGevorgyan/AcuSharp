namespace AcuSharp.Integration.Models
{
    /// <summary>
    /// Represents session context details for executing Acumatica operations in a scoped environment,
    /// such as within a <see cref="PXLoginScope"/>. Useful for impersonation or system-level actions.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ACSPSessionDetails"/> class with the specified parameters.
    /// </remarks>
    /// <param name="username"></param>
    /// <param name="companyName"></param>
    /// <param name="branchID"></param>
    /// <param name="screenID"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public sealed class ACSPSessionDetails(string username, string companyName, int? branchID = null, string screenID = null)
    {
        /// <summary>
        /// The username that will be used to create the <see cref="PXLoginScope"/>.
        /// This should be a valid Acumatica user (e.g., "admin").
        /// </summary>
        public string Username { get; } = !string.IsNullOrWhiteSpace(username) ? username : throw new ArgumentNullException(nameof(username));

        /// <summary>
        /// The company name used in the login scope. 
        /// If not set, it should default to the current or first available company.
        /// </summary>
        public string CompanyName { get; } = !string.IsNullOrWhiteSpace(companyName) ? companyName : throw new ArgumentNullException(nameof(companyName));

        /// <summary>
        /// The branch ID to associate with the session.
        /// This can be used to simulate actions taken within a specific branch.
        ///  <para>
        /// Can be <see langword="null"/> if branch context is not required for this session.
        /// </para>
        /// </summary>
        public int? BranchID { get; } = branchID;

        /// <summary>
        /// The screen ID used in the login scope.
        /// This can be used to simulate that an action was performed from a specific Acumatica screen (e.g., "SO301000").
        /// <para>
        /// Can be <see langword="null"/> if screen context is not needed or not applicable.
        /// </para>
        /// </summary>
        public string ScreenID { get; } = screenID;
    }

}
