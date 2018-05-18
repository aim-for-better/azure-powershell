﻿namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilenamesCharactersValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private IEnumerable<Configuration.CodePointRange> _blacklistOfCodePointRanges;
        private IEnumerable<int> _blacklistOfCodePoints;
        #endregion

        #region Constructors
        public FilenamesCharactersValidation(IConfiguration configuration): base(configuration, ValidationType.FilenameCharacters)
        {
            this._blacklistOfCodePointRanges = configuration.BlacklistOfCodePointRanges().ToList();
            this._blacklistOfCodePoints = configuration.BlacklistOfCodePoints().ToList();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo file)
        {
            return Validate((INamedObjectInfo)file);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo file)
        {
            return Validate((INamedObjectInfo)file);
        }

        #endregion

        #region Private methods

        private IValidationResult Validate (INamedObjectInfo node)
        {
            string name = node.Name;
            List<int> positions = new List<int>();
            for (int i = 0; i < name.Length; ++i)
            {
                if (IsBlacklisted(name[i]))
                {
                    positions.Add(i);
                }
            }

            if (positions.Count() > 0)
            {
                string description = $"File {node.Name} has an unsupported character in position";
                if (positions.Count() > 1)
                {
                    description += "s";
                }
                description += " ";
                description += String.Join(", ", positions);
                description += ".";

                return new ValidationResult
                {
                    Result = Result.Fail,
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = this.ValidationType,
                    Description = description,
                    Positions = positions
                };
            }

            return this.SuccessfulResult;
        }

        private bool IsBlacklisted(char aChar)
        {
            return 
                Char.IsHighSurrogate(aChar) ||
                _blacklistOfCodePointRanges.Any(range => range.Includes(aChar)) ||
                _blacklistOfCodePoints.Contains(aChar);
        }

        #endregion

    }
}
