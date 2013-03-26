using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BackgroundJobsLib;
using BackgroundJobsLib.Interop;
using FarNet;

namespace BackgroundJobs
{
    /// <summary>
    /// Provides Far manager interface for <see cref="IFileOperation"/>.
    /// </summary>
    [Guid("4C8259BE-A3F0-4EC0-90B8-F4699652FB42")]
    [ModuleTool(Name = "Background Jobs", Options = ModuleToolOptions.Panels)]
    public class BackgroundJobsModule : ModuleTool
    {
        private static List<FileOperationParams> _queue = new List<FileOperationParams>();

        /// <summary>
        /// Handles background jobs menu item call in panels menu.
        /// </summary>
        public override void Invoke(object sender, ModuleToolEventArgs e)
        {
            if (null == Far.Net.Panel)
            {
                Far.Net.Message(Strings.ErrorNoPanel,
                                Strings.ErrorHeader,
                                MessageOptions.Error | MessageOptions.Ok);
                return;
            }

            if (null == Far.Net.Panel.SelectedFiles)
            {
                Far.Net.Message(Strings.ErrorNoFilesSelected,
                                Strings.ErrorHeader,
                                MessageOptions.Error | MessageOptions.Ok);
                return;
            }

            ShowOperationsMenu();
        }

        private static void ShowOperationsMenu()
        {
            var operationsMenu = Far.Net.CreateMenu();
            operationsMenu.Add(Strings.MenuCopy, CopyHandle);
            operationsMenu.Add(Strings.MenuMove, MoveHandle);
            operationsMenu.Add(Strings.MenuDelete, DeleteHandle);
            operationsMenu.Add(string.Empty).IsSeparator = true;
            operationsMenu.Add(Strings.MenuExecute, ExecuteHandle);

            operationsMenu.Show();
        }

        private static void CopyHandle(object sender, MenuEventArgs args)
        {
            IPanel activePanel = Far.Net.Panel;
            string sourceDir = activePanel.CurrentDirectory;
            string destDir = Far.Net.Panel2.CurrentDirectory;

            foreach (var file in activePanel.SelectedFiles)
            {
                string sourceFullName = Path.Combine(sourceDir, file.Name);
                _queue.Add(new FileOperationParams(sourceFullName,
                                                   destDir,
                                                   file.Name,
                                                   FileOperationType.Copy));
            }

            Task.Factory.StartNew(WorkerThreadProc);
        }

        private static void MoveHandle(object sender, EventArgs args)
        {
            IPanel activePanel = Far.Net.Panel;
            string sourceDir = activePanel.CurrentDirectory;
            string destDir = Far.Net.Panel2.CurrentDirectory;

            foreach (var file in activePanel.SelectedFiles)
            {
                string sourceFullName = Path.Combine(sourceDir, file.Name);
                _queue.Add(new FileOperationParams(sourceFullName,
                                                   destDir,
                                                   file.Name,
                                                   FileOperationType.Move));
            }

            Task.Factory.StartNew(WorkerThreadProc);
        }

        private static void DeleteHandle(object sender, EventArgs args)
        {
            IPanel activePanel = Far.Net.Panel;
            string sourceDir = activePanel.CurrentDirectory;

            foreach (var file in activePanel.SelectedFiles)
            {
                string sourceFullName = Path.Combine(sourceDir, file.Name);
                _queue.Add(new FileOperationParams(sourceFullName,
                                                   null,
                                                   null,
                                                   FileOperationType.Delete));
            }

            Task.Factory.StartNew(WorkerThreadProc);
        }

        private static void ExecuteHandle(object sender, EventArgs args)
        {
            Task.Factory.StartNew(WorkerThreadProc);
        }

        private static void WorkerThreadProc()
        {
            FileOperation fileOperation = new FileOperation();
            foreach (var operationSettings in _queue)
            {
                switch (operationSettings.OperationType)
                {
                    case FileOperationType.Copy:
                        fileOperation.CopyItem(operationSettings.Source,
                                               operationSettings.Destination,
                                               operationSettings.NewName);
                        break;
                    case FileOperationType.Move:
                        fileOperation.MoveItem(operationSettings.Source,
                                               operationSettings.Destination,
                                               operationSettings.NewName);
                        break;
                    case FileOperationType.Delete:
                        fileOperation.DeleteItem(operationSettings.Source);
                        break;
                }
            }

            _queue.Clear();

            fileOperation.PerformOperations();
            fileOperation.Dispose();
        }
    }
}