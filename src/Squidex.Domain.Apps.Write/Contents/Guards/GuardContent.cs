﻿// ==========================================================================
//  GuardContent.cs
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex Group
//  All rights reserved.
// ==========================================================================

using Squidex.Domain.Apps.Core.Contents;
using Squidex.Domain.Apps.Write.Contents.Commands;
using Squidex.Infrastructure;

namespace Squidex.Domain.Apps.Write.Contents.Guards
{
    public static class GuardContent
    {
        public static void CanCreate(CreateContent command)
        {
            Guard.NotNull(command, nameof(command));

            Validate.It(() => "Cannot created content.", error =>
            {
                if (command.Data == null)
                {
                    error(new ValidationError("Data cannot be null.", nameof(command.Data)));
                }
            });
        }

        public static void CanUpdate(UpdateContent command)
        {
            Guard.NotNull(command, nameof(command));

            Validate.It(() => "Cannot update content.", error =>
            {
                if (command.Data == null)
                {
                    error(new ValidationError("Data cannot be null.", nameof(command.Data)));
                }
            });
        }

        public static void CanPatch(PatchContent command)
        {
            Guard.NotNull(command, nameof(command));

            Validate.It(() => "Cannot patch content.", error =>
            {
                if (command.Data == null)
                {
                    error(new ValidationError("Data cannot be null.", nameof(command.Data)));
                }
            });
        }

        public static void CanChangeContentStatus(Status status, ChangeContentStatus command)
        {
            Guard.NotNull(command, nameof(command));

            Validate.It(() => "Cannot change status.", error =>
            {
                if (!StatusFlow.Exists(command.Status) || !StatusFlow.CanChange(status, command.Status))
                {
                    error(new ValidationError($"Content cannot be changed from status {status} to {command.Status}.", nameof(command.Status)));
                }
            });
        }

        public static void CanDelete(DeleteContent command)
        {
            Guard.NotNull(command, nameof(command));
        }
    }
}
