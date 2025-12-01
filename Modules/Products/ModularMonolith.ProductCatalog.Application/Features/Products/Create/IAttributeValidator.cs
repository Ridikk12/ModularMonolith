using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IAttributeValidator
{
    Task ValidateAndThrow(Guid attributeId, List<string> selectedValues, CancellationToken cancellationToken);
}