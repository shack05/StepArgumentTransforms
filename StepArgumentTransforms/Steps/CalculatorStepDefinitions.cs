using System;
using TechTalk.SpecFlow;

namespace StepArgumentTransforms.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        [Given("the first number is (.*)")]
        public void SetFirstNumber(int number) { }

        [Given("the second number is (.*)")]
        public void SetSecondNumber(int number) { throw new Exception("Throwing on purpose"); }

        [When("the two numbers are (added|subtracted)")]
        public void WhenTheTwoNumbersAre(Operation operation) { }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result) { }

        [StepArgumentTransformation]
        public Operation ParseOperation(string operand)
        {
            Console.WriteLine("Running step argument transformation.");
            // I know specflow can parse enums out of the box, but just using as an example
            return Enum.Parse<Operation>(operand, ignoreCase: true);
        }
    }

    public enum Operation
    {
        Added,
        Subtracted
    }
}
