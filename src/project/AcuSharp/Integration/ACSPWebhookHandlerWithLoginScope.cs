namespace AcuSharp.Integration
{
    /// <summary>
    /// Abstract base class for handling incoming webhook requests in Acumatica ERP.
    /// <para>
    /// This class wraps the webhook execution inside a <see cref="PXLoginScope"/> using provided session credentials,
    /// ensuring that all operations run under an authorized and scoped session.
    /// </para>
    /// <para>
    /// Derived classes must implement security validation (<see cref="EnsureRequestIsSecure"/>)
    /// and the actual webhook processing logic (<see cref="ProcessWebhookAsync"/>).
    /// </para>
    /// </summary>
    public abstract class ACSPWebhookHandlerWithLogin : IWebhookHandler
    {
        #region Properties
        /// <summary>
        /// Represents session context details for executing Acumatica operations in a scoped environment,
        /// such as within a <see cref="PXLoginScope"/>.
        /// </summary>
        protected abstract ACSPSessionDetails SessionDetails { get; }
        #endregion


        #region Methods
        /// <summary>
        /// Main entry point to handle the webhook request.
        /// Automatically wraps the logic in a <see cref="PXLoginScope"/> using the provided credentials.
        /// </summary>
        /// <param name="context">The webhook context data.</param>
        /// <param name="cancellationToken">Cancellation token for the async operation.</param>
        public Task HandleAsync(WebhookContext context, CancellationToken cancellationToken)
        {
            EnsureRequestIsSecure(context, cancellationToken);
            using var loginScope = CreateLoginScope();
            SetRequiredSessionDetails();
            return ProcessWebhookAsync(context, cancellationToken, loginScope);
        }

        /// <summary>
        /// Ensures that the incoming webhook request is secure and authorized.
        /// Implement this method to enforce security validations such as verifying signatures,
        /// event authenticity, or custom authorization rules.
        /// Throw an exception if the request fails any security check.
        /// </summary>
        /// <param name="context">The webhook context containing the incoming request data.</param>
        /// <param name="cancellationToken">Token used to observe cancellation requests.</param>
        /// You may inspect it if necessary, but do not dispose it manually.
        protected abstract void EnsureRequestIsSecure(WebhookContext context, CancellationToken cancellationToken);

        /// <summary>
        /// The implementation logic that handles the actual webhook request.
        /// </summary>
        /// <param name="context">The incoming webhook request data.</param>
        /// <param name="cancellationToken">Token used to cancel the request if needed.</param>
        /// <param name="loginScope">
        /// The <see cref="PXLoginScope"/> used to authorize Acumatica access for this webhook execution.
        /// It is already active and will be disposed automatically after this method completes.
        /// You may inspect or use it within the scope, but DO NOT DISPOSE it manually.
        /// </param>
        protected abstract Task ProcessWebhookAsync(WebhookContext context, CancellationToken cancellationToken, IDisposable loginScope);

        /// <summary>
        /// Creates a new <see cref="PXLoginScope"/> using the provided <see cref="ACSPSessionDetails.Username"/> and <see cref="ACSPSessionDetails.CompanyName"/>.
        /// </summary>
        private IDisposable CreateLoginScope()
        {
            if (string.IsNullOrWhiteSpace(SessionDetails.Username))
                throw new ArgumentNullException(nameof(SessionDetails.Username), "Username cannot be null or empty.");

            string resolvedCompany = SessionDetails.CompanyName;

            if (string.IsNullOrWhiteSpace(resolvedCompany))
            {
                resolvedCompany = PXAccess.GetCompanyName();

                if (string.IsNullOrWhiteSpace(resolvedCompany) && PXDatabase.Companies.Length > 0)
                {
                    resolvedCompany = PXDatabase.Companies[0];
                }
            }

            string finalUsername = !string.IsNullOrWhiteSpace(resolvedCompany)
                ? $"{SessionDetails.Username}@{resolvedCompany}"
                : SessionDetails.Username;

            return new PXLoginScope(finalUsername);
        }

        /// <summary>
        /// Sets the required session details such as BranchID and ScreenID.
        /// </summary>
        protected virtual void SetRequiredSessionDetails()
        {
            if (SessionDetails.BranchID.HasValue)
            {
                PXLogin.SetBranchID(SessionDetails.BranchID.Value);
            }

            if (!string.IsNullOrWhiteSpace(SessionDetails.ScreenID))
            {
                PXContext.SetScreenID(SessionDetails.ScreenID);
            }
        }

        #endregion
    }
}
