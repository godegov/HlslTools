﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using NSubstitute;
using ShaderTools.Editor.VisualStudio.Hlsl.Parsing;
using ShaderTools.Editor.VisualStudio.Hlsl.Tagging.Squiggles;
using ShaderTools.Editor.VisualStudio.Tests.Hlsl.Support;
using ShaderTools.Testing.TestResources.Hlsl;
using Xunit;

namespace ShaderTools.Editor.VisualStudio.Tests.Hlsl.Tagging.Squiggles
{
    public class SyntaxErrorTaggerTests : AsyncTaggerTestsBase
    {
        [Theory]
        [HlslTestSuiteData]
        public async Task CanDoTagging(string testFile)
        {
            await RunTestAsync<SyntaxErrorTagger, IErrorTag>(testFile, CreateTagger);
        }

        private SyntaxErrorTagger CreateTagger(BackgroundParser backgroundParser, ITextBuffer textBuffer)
        {
            var textView = Substitute.For<ITextView>();
            textView.TextSnapshot.Returns(textBuffer.CurrentSnapshot);

            return new SyntaxErrorTagger(
                textView, textBuffer, backgroundParser, new FakeOptionsService());
        }

        protected override bool MustCreateTagSpans => false;
    }
}