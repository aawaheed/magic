/*
 * Copyright (c) Thomas Hansen, 2021 - 2023 thomas@ainiro.io.
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.git.signatures
{
    public abstract class GitSignature : ISlotSignature
    {
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        protected static SlotChild Option(string name, string type, string description, bool required = false, string defaultValue = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                DefaultValue = defaultValue,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    public class GitBranchListSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("remote", "bool", "List remote branches", defaultValue: "false"),
            Option("all", "bool", "List all branches", defaultValue: "false"),
        };
    }

    public class GitStatusSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("porcelain", "bool", "Use porcelain status output", defaultValue: "false"),
            Option("branch", "bool", "Include branch information", defaultValue: "false"),
            Option("structured", "bool", "Return status lines as child nodes", defaultValue: "false"),
        };
    }

    public class GitPullSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("remote", "string", "Remote to pull from", defaultValue: "origin"),
            Option("branch", "string", "Branch to pull"),
            Option("rebase", "bool", "Use rebase while pulling", defaultValue: "false"),
            Option("ff-only", "bool", "Only allow fast-forward pulls", defaultValue: "false"),
        };
    }

    public class GitFetchSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("remote", "string", "Remote to fetch from", defaultValue: "origin"),
            Option("refspec", "string", "Optional refspec to fetch"),
        };
    }

    public class GitRemoteAddSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("name", "string", "Remote name", defaultValue: "origin"),
            Option("url", "string", "Remote URL", true),
        };
    }

    public class GitHubRepoCreateSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("owner", "string", "Organization owner; omit to create under the authenticated user"),
            Option("private", "bool", "Whether the repository is private", defaultValue: "false"),
            Option("description", "string", "Repository description"),
            Option("homepage", "string", "Repository homepage URL"),
            Option("auto-init", "bool", "Initialize the repository", defaultValue: "false"),
            Option("default-branch", "string", "Default branch name"),
            Option("gitignore-template", "string", "GitHub gitignore template"),
            Option("license-template", "string", "GitHub license template"),
        };
    }

    public class GitHubRepoDeleteSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("owner", "string", "Repository owner; omit to delete from the authenticated user"),
        };
    }

    public class GitHubRepoListSignature : GitSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("owner", "string", "Organization owner; omit to list authenticated user repositories"),
            Option("visibility", "string", "Repository visibility filter"),
            Option("type", "string", "Repository type filter"),
            Option("per-page", "int", "Number of repositories per page"),
            Option("page", "int", "Page number"),
        };
    }
}
