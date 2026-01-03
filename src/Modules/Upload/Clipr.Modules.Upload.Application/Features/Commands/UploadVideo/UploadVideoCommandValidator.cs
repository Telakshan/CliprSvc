using FluentValidation;

namespace Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;

public class UploadVideoCommandValidator : AbstractValidator<UploadVideoCommand>
{
    public UploadVideoCommandValidator()
    {
        RuleFor(p => p.VideoFile)
            .NotEmpty().WithMessage("Video file to upload cannot be empty!");
        RuleFor(p => p.VideoFile.Length)
            .GreaterThan(0).WithMessage("Video file size must be greater than zero!");
    }
}
