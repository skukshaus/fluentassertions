using System;

namespace FluentAssertions.Equivalency
{
    internal class SystemTypeEquivalencyStep : IEquivalencyStep
    {
        /// <summary>
        /// Gets a value indicating whether this step can handle the current subject and/or expectation.
        /// </summary>
        public bool CanHandle(EquivalencyValidationContext context, IEquivalencyAssertionOptions config)
        {
            Type type = context.RuntimeType;

            return (type != null) &&
                   (type != typeof (object)) &&
                   (type.Namespace == typeof (int).Namespace);
        }

        /// <summary>
        /// Applies a step as part of the task to compare two objects for structural equality.
        /// </summary>
        /// <value>
        /// Should return <c>true</c> if the subject matches the expectation or if no additional assertions
        /// have to be executed. Should return <c>false</c> otherwise.
        /// </value>
        /// <remarks>
        /// May throw when preconditions are not met or if it detects mismatching data.
        /// </remarks>
        public bool Handle(EquivalencyValidationContext context, IEquivalencyValidator structuralEqualityValidator, IEquivalencyAssertionOptions config)
        {
            context.Subject.Should().Be(context.Expectation, context.Reason, context.ReasonArgs);

            return true;
        }
    }
}