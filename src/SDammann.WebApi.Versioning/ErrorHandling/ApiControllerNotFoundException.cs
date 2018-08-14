namespace SDammann.WebApi.Versioning.ErrorHandling {
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the exception that is thrown when an api controller is not found
    /// </summary>
    [Serializable]
    public class ApiControllerNotFoundException : BaseApiException {
        private readonly ControllerIdentification _controllerIdentification;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param><param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param><exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception><exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected ApiControllerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
            this._controllerIdentification = (ControllerIdentification) info.GetValue("_controllerIdentification", typeof (ControllerIdentification));
        }

        /// <summary>
        /// Gets the controller name used in the request. Note that this may be null.
        /// </summary>
        public ControllerIdentification ControllerIdentification {
            get { return this._controllerIdentification; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        /// <param name="controllerIdentification"></param>
        public ApiControllerNotFoundException(string message, ControllerIdentification controllerIdentification) : base(message) {
            this._controllerIdentification = controllerIdentification;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class.
        /// </summary>
        public ApiControllerNotFoundException() {}

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param><param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param><exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic). </exception><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/></PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);

            info.AddValue("_controllerIdentification", this._controllerIdentification);
        }

        /// <summary>
        /// Creates a default exception 
        /// </summary>
        /// <returns></returns>
        public static ApiControllerNotFoundException Create(ControllerIdentification controllerIdentification) {
            return new ApiControllerNotFoundException(String.Format(ExceptionResources.ApiControllerNotFound, controllerIdentification), controllerIdentification);
        }
    }
}