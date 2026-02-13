/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.system.terminal
{
    /// <summary>
    /// [system.execute] slot that allows you to execute a system process,
    /// passing in arguments, and returning the result of the execution.
    /// </summary>
    [Slot(Name = "system.execute")]
    public class TerminalExecute : ISlotAsync
    {
        /// <summary>
        /// Slot implementation.
        /// </summary>
        /// <param name="signaler">Signaler that raised signal.</param>
        /// <param name="input">Arguments to slot.</param>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var args = GetArgs(input);

            var startInfo = string.IsNullOrWhiteSpace(args.Arguments)
                ? new ProcessStartInfo(args.Command)
                : new ProcessStartInfo(args.Command, args.Arguments);

            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            if (!string.IsNullOrWhiteSpace(args.WorkingDirectory))
                startInfo.WorkingDirectory = args.WorkingDirectory;

            using var process = new Process { StartInfo = startInfo };
            process.Start();

            var stdoutTask = process.StandardOutput.ReadToEndAsync();
            var stderrTask = process.StandardError.ReadToEndAsync();

            await Task.WhenAll(stdoutTask, stderrTask, process.WaitForExitAsync());

            if (process.ExitCode != 0)
            {
                var error = string.IsNullOrWhiteSpace(stderrTask.Result)
                    ? stdoutTask.Result
                    : stderrTask.Result;
                throw new HyperlambdaException(error?.TrimEnd());
            }

            input.Value = stdoutTask.Result?.TrimEnd();
        }

        #region [ -- Private helper methods -- ]

        (string Command, string Arguments, string WorkingDirectory) GetArgs(Node input)
        {
            var command = input.GetEx<string>();
            if (string.IsNullOrWhiteSpace(command))
                throw new HyperlambdaException("Missing required argument value");

            var arguments = input.Children.FirstOrDefault(x => x.Name == "args")?.GetEx<string>();
            var workingDirectory = input.Children.FirstOrDefault(x => x.Name == "working-directory")?.GetEx<string>();

            input.Clear();
            input.Value = null;

            return (command, arguments, workingDirectory);
        }

        #endregion
    }
}
