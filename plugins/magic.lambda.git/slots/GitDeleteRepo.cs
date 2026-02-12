/*
 * Copyright (c) Thomas Hansen, 2021 - 2023 thomas@ainiro.io.
 */

using System.IO;
using System.Threading.Tasks;
using magic.node;
using magic.node.contracts;
using magic.signals.contracts;

namespace magic.lambda.git
{
    /// <summary>
    /// [git.delete-repo] slot to delete existing repo.
    /// </summary>
    [Slot(Name = "git.delete-repo")]
    public class GitDeleteRepo : ISlotAsync
    {
        readonly IRootResolver _rootResolver;

        public GitDeleteRepo(IRootResolver rootResolver)
        {
            _rootResolver = rootResolver;
        }

        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var path = GetArgs(input);
            var fullPath = GitSlotHelpers.ResolveRepoPath(_rootResolver, path);

            if (!Directory.Exists(fullPath))
                return;

            GitSlotHelpers.EnsureNotDynamicRoot(_rootResolver, fullPath);
            Directory.Delete(fullPath, true);
        }

        #region [ -- Private helper methods -- ]

        string GetArgs(Node input)
        {
            var path = GitSlotHelpers.GetRequiredPrimaryValue(input);

            input.Clear();
            input.Value = null;

            return path;
        }

        #endregion
    }
}
