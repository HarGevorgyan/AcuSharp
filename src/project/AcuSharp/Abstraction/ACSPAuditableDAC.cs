namespace AcuSharp.Abstraction
{
    /// <summary>
    /// Provides a reusable base class for Acumatica DACs that require standard audit fields, 
    /// including CreatedByID, CreatedDateTime, LastModifiedByID, LastModifiedDateTime, and Tstamp, etc.
    /// Inherit from this class to enable consistent auditing and automatic population of these fields.
    /// </summary>
    public abstract class ACSPAuditableDAC : PXBqlTable
    {
        #region CreatedByID
        /// <inheritdoc cref="PXDBCreatedByIDAttribute"/>
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID
        {
            get;
            set;
        }
        /// <summary>
        /// Abstract class that represents the CreatedByID field in the database.
        /// </summary>
        public abstract class createdByID : BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        /// <inheritdoc cref="PXDBCreatedByScreenIDAttribute"/>
        [PXDBCreatedByScreenID]
        public virtual string CreatedByScreenID
        {
            get;
            set;
        }
        /// <summary>
        /// Abstract class that represents the CreatedByScreenID field in the database.
        /// </summary>
        public abstract class createdByScreenID : BqlString.Field<createdByScreenID> { }

        #endregion

        #region CreatedDateTime
        /// <inheritdoc cref="PXDBCreatedDateTimeAttribute"/>

        [PXDBCreatedDateTime]
        public virtual DateTime? CreatedDateTime { get; set; }
        /// <summary>
        /// Abstract class that represents the CreatedDateTime field in the database.
        /// </summary>
        public abstract class createdDateTime : BqlDateTime.Field<createdDateTime> { }

        #endregion

        #region LastModifiedByID
        /// <inheritdoc cref="PXDBLastModifiedByIDAttribute"/>
        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID
        {
            get;
            set;
        }
        /// <summary>
        /// Abstract class that represents the LastModifiedByID field in the database.
        /// </summary>
        public abstract class lastModifiedByID : BqlGuid.Field<lastModifiedByID> { }

        #endregion

        #region LastModifiedByScreenID
        /// <inheritdoc cref="PXDBLastModifiedByScreenIDAttribute"/>
        [PXDBLastModifiedByScreenID]
        public virtual string LastModifiedByScreenID
        {
            get;
            set;
        }
        /// <summary>
        /// Abstract class that represents the LastModifiedByScreenID field in the database.
        /// </summary>
        public abstract class lastModifiedByScreenID : BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        /// <inheritdoc cref="PXDBLastModifiedDateTimeAttribute"/>
        [PXDBLastModifiedDateTime]
        public virtual DateTime? LastModifiedDateTime
        {
            get;
            set;
        }
        /// <summary>
        /// Abstract class that represents the LastModifiedDateTime field in the database.
        /// </summary>
        public abstract class lastModifiedDateTime : BqlDateTime.Field<lastModifiedDateTime> { }

        #endregion

        #region tstamp
        /// <inheritdoc cref="PXDBTimestampAttribute"/>
        [PXDBTimestamp]
        public virtual byte[] tstamp { get; set; }
        /// <summary>
        /// Abstract class that represents the tstamp field in the database.
        /// </summary>
        public abstract class Tstamp : BqlByteArray.Field<Tstamp> { }
        #endregion
    }
}
