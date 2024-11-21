using System;
using ModularMonolith.Exceptions.Abstraction.Domain;

namespace ModularMonolith.Products.Domain.Exceptions;

public class InvalidAttributeValuesException : DomainException
{
    public InvalidAttributeValuesException(Guid attributeId, string value) : base(
        $"Attribute value '{value}' is incorrect for attribute with id: {attributeId}", ExceptionCodes.AttributeValueIncorrect)
    {
    }
}