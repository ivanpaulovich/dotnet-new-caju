namespace MyBasic.UnitTests.InputValidationTests
{
    using System;
    using MyBasic.Application.Boundaries.Transfer;
    using MyBasic.Application.Exceptions;
    using MyBasic.Domain.ValueObjects;
    using Xunit;

    public sealed class TransferInputValidationTests
    {
        [Fact]
        public void GivenEmptyOriginAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new TransferInput(
                    Guid.Empty,
                    Guid.NewGuid(),
                    new PositiveMoney(10)
                ));
            Assert.Contains("originAccountId", actualEx.Message);
        }

        [Fact]
        public void GivenEmptyDestinationAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new TransferInput(
                    Guid.NewGuid(),
                    Guid.Empty,
                    new PositiveMoney(10)
                ));
            Assert.Contains("destinationAccountId", actualEx.Message);
        }

        [Fact]
        public void GivenNullAmount_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new TransferInput(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    null
                ));
            Assert.Contains("amount", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new TransferInput(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}