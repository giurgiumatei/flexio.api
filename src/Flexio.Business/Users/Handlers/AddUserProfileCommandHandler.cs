﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Azure.Storage.Services;
using Flexio.Business.Users.Commands;
using Flexio.Data;
using Flexio.Data.Models.Users;
using MediatR;

namespace Flexio.Business.Users.Handlers;

public class AddUserProfileCommandHandler : IRequestHandler<AddUserProfileCommand, bool>
{
    private readonly FlexioContext _context;
    private IBlobStorageService _storageService;
    private AddUserProfileCommand _command;

    public AddUserProfileCommandHandler(FlexioContext context, IBlobStorageService storageService)
    {
        _context = context;
        _storageService = storageService;
    }

    public async Task<bool> Handle(AddUserProfileCommand command, CancellationToken cancellationToken)
    {
        _command = command;

        var blobUri = await UploadProfileImageToStorage();

        _context.Users.Add(new User
        {
            DateAdded = DateTime.Now,
            UserDetail = new UserDetail
            {
                City = _command.City,
                FirstName = _command.FirstName,
                LastName = _command.LastName,
                Country = _command.Country,
                GenderId = _command.GenderId,
                DisplayName = GetDisplayName(),
                ProfileImageUrl = blobUri
            }
        });

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    private async Task<string> UploadProfileImageToStorage()
    {
        return await _storageService.Upload(GetContainerName(), _command.ProfileImage, "Profile Image");
    }

    private string GetDisplayName() => _command.FirstName + " " + _command.LastName;

    private string GetContainerName() =>
        _command.FirstName.ToLower() + "-" + _command.LastName.ToLower();
}