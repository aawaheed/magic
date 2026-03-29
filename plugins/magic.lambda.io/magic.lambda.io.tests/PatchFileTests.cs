/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using Xunit;
using magic.lambda.io.tests.helpers;
using magic.node;
using magic.node.extensions;

namespace magic.lambda.io.tests
{
    public class PatchFileTests
    {
        [Fact]
        public void PatchFile_ThrowsForMissingPayload()
        {
            var fileService = new FileService
            {
                LoadAction = path => "foo",
                SaveAction = (path, content) => Assert.True(false, "Save should not be called for invalid patches.")
            };

            var exception = Assert.Throws<HyperlambdaException>(() => Common.Evaluate("""
io.file.patch:/existing.txt
""", fileService));

            Assert.Equal("Missing patch.", exception.Message);
        }

        [Fact]
        public void PatchFile_ThrowsForEmptyPayload()
        {
            var fileService = new FileService
            {
                LoadAction = path => "foo",
                SaveAction = (path, content) => Assert.True(false, "Save should not be called for invalid patches.")
            };

            var exception = Assert.Throws<HyperlambdaException>(() => Common.Evaluate("""
io.file.patch:/existing.txt
   .:
""", fileService));

            Assert.Equal("Patch is empty.", exception.Message);
        }

        [Fact]
        public void PatchFile_AppliesPatchEndingWithTrailingNewline()
        {
            var saveInvoked = false;
            var fileService = new FileService
            {
                LoadAction = path => "line1\nline2",
                SaveAction = (path, content) =>
                {
                    saveInvoked = true;
                    Assert.Equal("line1\nline2 updated", content);
                }
            };

            Common.Evaluate("""
io.file.patch:/existing.txt
   .:@"
@@ -1,2 +1,2 @@
 line1
-line2
+line2 updated
"
""", fileService);

            Assert.True(saveInvoked);
        }

        [Fact]
        public void PatchFile_AppliesMultipleHunksInSingleFile()
        {
            var saveInvoked = false;
            var fileService = new FileService
            {
                LoadAction = path => "line1\nline2\nline3\nline4",
                SaveAction = (path, content) =>
                {
                    saveInvoked = true;
                    Assert.Equal("line1 updated\nline2\nline3\nline4 updated", content);
                }
            };

            Common.Evaluate("""
io.file.patch:/existing.txt
   .:@"
@@ -1,2 +1,2 @@
-line1
+line1 updated
 line2
@@ -3,2 +3,2 @@
 line3
-line4
+line4 updated
"
""", fileService);

            Assert.True(saveInvoked);
        }

        [Fact]
        public void PatchFile_RejectsOutOfOrderHunks()
        {
            var fileService = new FileService
            {
                LoadAction = path => "line1\nline2\nline3\nline4",
                SaveAction = (path, content) => Assert.True(false, "Save should not be called for invalid patches.")
            };

            var exception = Assert.Throws<HyperlambdaException>(() => Common.Evaluate("""
io.file.patch:/existing.txt
   .:@"
@@ -3,2 +3,2 @@
 line3
-line4
+line4 updated
@@ -1,2 +1,2 @@
-line1
+line1 updated
 line2
"
""", fileService));

            Assert.Equal("Patch hunks are overlapping or out of order.", exception.Message);
        }

        [Fact]
        public void PatchFile_RejectsPatchWithoutHunks()
        {
            var fileService = new FileService
            {
                LoadAction = path => "line1\nline2",
                SaveAction = (path, content) => Assert.True(false, "Save should not be called for invalid patches.")
            };

            var exception = Assert.Throws<HyperlambdaException>(() => Common.Evaluate("""
io.file.patch:/existing.txt
   .:@"
--- a/existing.txt
+++ b/existing.txt
"
""", fileService));

            Assert.Equal("Patch does not contain any hunks.", exception.Message);
        }

        [Fact]
        public void PatchFile_RejectsUnexpectedPatchLines()
        {
            var fileService = new FileService
            {
                LoadAction = path => "line1\nline2",
                SaveAction = (path, content) => Assert.True(false, "Save should not be called for invalid patches.")
            };

            var exception = Assert.Throws<HyperlambdaException>(() => Common.Evaluate("""
io.file.patch:/existing.txt
   .:this is not a diff
""", fileService));

            Assert.Equal("Invalid patch.", exception.Message);
        }
    }
}
