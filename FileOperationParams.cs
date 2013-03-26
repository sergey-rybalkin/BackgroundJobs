using System;

namespace BackgroundJobs
{
    internal enum FileOperationType
    {
        Copy,
        Move,
        Delete
    }

    /// <summary>
    /// Contains parameters for file operations.
    /// </summary>
    internal class FileOperationParams : Tuple<string, string, string, FileOperationType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperationParams"/> class.
        /// </summary>
        public FileOperationParams(string source, 
                                   string destination, 
                                   string newName, 
                                   FileOperationType type)
            : base(source, destination, newName, type)
        {
        }

        /// <summary>
        /// Gets the source file or directory path.
        /// </summary>
        public string Source
        {
            get { return Item1; }
        }

        /// <summary>
        /// Gets the destination file or directory path.
        /// </summary>
        public string Destination
        {
            get { return Item2; }
        }

        /// <summary>
        /// Gets the new name of the file or directory.
        /// </summary>
        public string NewName
        {
            get { return Item3; }
        }

        /// <summary>
        /// Gets the type of the operation.
        /// </summary>
        public FileOperationType OperationType
        {
            get { return Item4; }
        }
    }
}