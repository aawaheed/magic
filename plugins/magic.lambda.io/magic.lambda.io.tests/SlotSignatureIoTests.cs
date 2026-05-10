/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using Xunit;
using magic.lambda.io.tests.helpers;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.io.tests
{
    public class SlotSignatureIoTests
    {
        [Fact]
        public void ReturnsSearchFileChildren()
        {
            var lambda = Common.Evaluate(@"slot.signature:io.file.search");
            var result = lambda.Children.First();
            var children = result.Children.First(x => x.Name == "children");
            var pattern = children.Children.First(x => x.Name == "pattern");
            var regex = children.Children.First(x => x.Name == "regex");

            Assert.Equal("string", pattern.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.True(pattern.Children.First(x => x.Name == "required").GetEx<bool>());
            Assert.Equal(SlotChildMode.ValueOrExpression.ToString(), pattern.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal(SlotChildCardinality.ExactlyOne.ToString(), pattern.Children.First(x => x.Name == "cardinality").GetEx<string>());
            Assert.Equal("false", regex.Children.First(x => x.Name == "default").GetEx<string>());
        }

        [Fact]
        public void ReturnsSaveFileAliasChildren()
        {
            var lambda = Common.Evaluate(@"slot.signature:save-file");
            var result = lambda.Children.First();
            var child = result.Children
                .First(x => x.Name == "children")
                .Children
                .First(x => x.Name == "*");

            Assert.Equal("string", child.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.True(child.Children.First(x => x.Name == "required").GetEx<bool>());
            Assert.Equal(SlotChildMode.ExecutableLambda.ToString(), child.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal(SlotChildCardinality.ExactlyOne.ToString(), child.Children.First(x => x.Name == "cardinality").GetEx<string>());
        }

        [Fact]
        public void ReturnsExecuteFileChildrenWithAliasSpecificPreprocess()
        {
            var lambda = Common.Evaluate(@"slot.signature:execute-file");
            var result = lambda.Children.First();
            var child = result.Children
                .First(x => x.Name == "children")
                .Children
                .First(x => x.Name == "*");

            Assert.Equal(SlotChildMode.Arguments.ToString(), child.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal(SlotChildPreprocess.UnwrapExpressions.ToString(), child.Children.First(x => x.Name == "preprocess").GetEx<string>());
            Assert.Equal(SlotChildRole.Arguments.ToString(), child.Children.First(x => x.Name == "role").GetEx<string>());
            Assert.Equal(SlotChildProjection.ArgumentBag.ToString(), child.Children.First(x => x.Name == "projection").GetEx<string>());
        }

        [Fact]
        public void ReturnsNestedZipContentChildren()
        {
            var lambda = Common.Evaluate(@"slot.signature:io.content.zip-stream");
            var result = lambda.Children.First();
            var entry = result.Children
                .First(x => x.Name == "children")
                .Children
                .First(x => x.Name == "*");
            var content = entry.Children
                .First(x => x.Name == "children")
                .Children
                .First(x => x.Name == "*");

            Assert.Equal("ZIP entry path", entry.Children.First(x => x.Name == "description").GetEx<string>());
            Assert.Equal("string|byte[]", content.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal(SlotChildCardinality.ExactlyOne.ToString(), content.Children.First(x => x.Name == "cardinality").GetEx<string>());
        }

        [Fact]
        public void OmitsChildrenForSimpleIoSlots()
        {
            var lambda = Common.Evaluate(@"slot.signature:io.file.load");
            var result = lambda.Children.First();

            Assert.DoesNotContain(result.Children, x => x.Name == "children");
        }

        [Fact]
        public void ReturnsFileListOutputContract()
        {
            var lambda = Common.Evaluate(@"slot.signature:io.file.list");
            var output = lambda.Children
                .First()
                .Children
                .First(x => x.Name == "output");

            Assert.Equal(SlotReturnsMode.Lambda.ToString(), output.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal("lambda", output.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Returns one unnamed child node per relative file path", output.Children.First(x => x.Name == "description").GetEx<string>());
        }

        [Fact]
        public void ReturnsFolderListOutputContract()
        {
            var lambda = Common.Evaluate(@"slot.signature:io.folder.list");
            var output = lambda.Children
                .First()
                .Children
                .First(x => x.Name == "output");

            Assert.Equal(SlotReturnsMode.Lambda.ToString(), output.Children.First(x => x.Name == "mode").GetEx<string>());
            Assert.Equal("lambda", output.Children.First(x => x.Name == "type").GetEx<string>());
            Assert.Equal("Returns one unnamed child node per relative folder path", output.Children.First(x => x.Name == "description").GetEx<string>());
        }
    }
}
