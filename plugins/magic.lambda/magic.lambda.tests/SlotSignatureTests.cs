/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using Xunit;
using System.Linq;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.tests
{
    public class SlotSignatureTests
    {
        [Fact]
        public void ReturnsSignatureForSingleSlot()
        {
            var lambda = Common.Evaluate(@"slot.signature:slot.description");
            var result = lambda.Children.First();
            var input = result.Children.First(x => x.Name == "input");
            var output = result.Children.First(x => x.Name == "output");

            Assert.Equal("string", input.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Name of the compiled slot to inspect", input.Children.First(x => x.Name == "description").GetEx<string>());
            Assert.True(input.Children.First(x => x.Name == "required").GetEx<bool>());
            Assert.Equal(SlotValueMode.ValueOrExpression.ToString(), input.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal(SlotReturnsMode.Value.ToString(), output.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal("string", output.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Resolves to the description of the requested slot", output.Children.First(x => x.Name == "description").GetEx<string>());
        }

        [Fact]
        public void ReturnsSignatureForCorrectAlias()
        {
            var lambda = Common.Evaluate(@"slot.signature:execute");
            var result = lambda.Children.First();
            var input = result.Children.First(x => x.Name == "input");
            var output = result.Children.First(x => x.Name == "output");

            Assert.Equal("string", input.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Name of the dynamic slot to invoke", input.Children.First(x => x.Name == "description").GetEx<string>());
            Assert.True(input.Children.First(x => x.Name == "required").GetEx<bool>());
            Assert.Equal(SlotValueMode.ValueOrExpression.ToString(), input.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal(SlotReturnsMode.Both.ToString(), output.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal("object", output.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Resolves to the invoked slot's value result and any returned child nodes", output.Children.First(x => x.Name == "description").GetEx<string>());
        }

        [Fact]
        public void OmitsInputWhenSlotDoesNotDocumentInput()
        {
            var lambda = Common.Evaluate(@"slot.signature:foo");
            var result = lambda.Children.First();
            var output = result.Children.First(x => x.Name == "output");

            Assert.DoesNotContain(result.Children, x => x.Name == "input");
            Assert.Equal(SlotReturnsMode.Value.ToString(), output.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal("string", output.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Resolves to the constant string \"OK\"", output.Children.First(x => x.Name == "description").GetEx<string>());
        }

        [Fact]
        public void OmitsOutputWhenSlotDoesNotDocumentOutput()
        {
            var lambda = Common.Evaluate(@"slot.signature:eval");
            var result = lambda.Children.First();
            var input = result.Children.First(x => x.Name == "input");

            Assert.Equal("lambda", input.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal(SlotValueMode.Expression.ToString(), input.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.DoesNotContain(result.Children, x => x.Name == "output");
        }

        [Fact]
        public void OmitsInputAndOutputWhenSlotDocumentsNeither()
        {
            var lambda = Common.Evaluate(@"slot.signature:.not-visible");
            var result = lambda.Children.First();

            Assert.Empty(result.Children);
        }

        [Fact]
        public void ThrowsForUnknownSlot()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"slot.signature:some.unknown.slot"));
        }
    }
}
